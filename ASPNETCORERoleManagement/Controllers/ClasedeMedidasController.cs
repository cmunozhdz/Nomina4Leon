using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCORERoleManagement.Data;
using ASPNETCORERoleManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using ASPNETCORERoleManagement.Services;

namespace ASPNETCORERoleManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClasedeMedidasController : Controller
    {
        private readonly ApplicationDbContext _context;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
        public ClasedeMedidasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClasedeMedidas
        public async Task<IActionResult> Index()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                return View(await _context.ClasedeMedida.ToListAsync());
            }
            else
            {
                var x = HttpContext.Session.GetString(SessionGpoCia);
                return View(await _context.ClasedeMedida.Where(c => c.Gbukrs == x).ToListAsync());
            }
            // return View(await _context.ClasedeMedida.ToListAsync());
        }

        // GET: ClasedeMedidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasedeMedida = await _context.ClasedeMedida
                .SingleOrDefaultAsync(m => m.Id == id);
            if (clasedeMedida == null)
            {
                return NotFound();
            }

            return View(clasedeMedida);
        }

        // GET: ClasedeMedidas/Create
        public IActionResult Create()
        {

            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:ClasedeMedidas");
                return RedirectToAction("Index", "GpoCiaGlobal");
                //return Redirect("GpoCiaGlobal/Index");
            }
            else
            {
                HttpContext.Session.SetString(SessionRegresa, "");

            }
            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            //            ViewBag.MassnType = new SelectList(list, "Value", "Text", "0");
            return View();
        }

        // POST: ClasedeMedidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Massn,Massn_desc,Massg,Massg_desc")] ClasedeMedida clasedeMedida)
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            clasedeMedida.Bukrs = clasedeMedida.Bukrs.PadLeft(4, '0');
            clasedeMedida.Gbukrs = clasedeMedida.Gbukrs.PadLeft(4, '0');
            clasedeMedida.Massg = clasedeMedida.Massg.PadLeft(2, '0');
            clasedeMedida.Massn = clasedeMedida.Massn.PadLeft(2, '0');
            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            int cnt = (from m in _context.Cat1
                       where m.Gbukrs == clasedeMedida.Gbukrs && m.Bukrs == clasedeMedida.Bukrs
                       select m.Gbukrs).Count();
            if (cnt == 0)
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(clasedeMedida);
            }

            int cnt2 = (from m in _context.ClasedeMedida
                        where m.Gbukrs == clasedeMedida.Gbukrs && m.Bukrs == clasedeMedida.Bukrs
                        && m.Massg == clasedeMedida.Massg && m.Massn == clasedeMedida.Massn && m.Id != clasedeMedida.Id
                        select m.Gbukrs).Count();
            if (cnt2 != 0)
            {
                ModelState.AddModelError("Massg", "Registro Duplicado");
                return View(clasedeMedida);
            }




            if (ModelState.IsValid)
            {
                _context.Add(clasedeMedida);
                await _context.SaveChangesAsync();
                TempData["message"] =  clasedeMedida.Gbukrs + "  Cía: " + clasedeMedida.Bukrs + " - " + clasedeMedida.Massg_desc + " - " + clasedeMedida.Massn_desc;
                return RedirectToAction(nameof(Create));
                //                return RedirectToAction(nameof(Index));
            }
            return View(clasedeMedida);
        }

        // GET: ClasedeMedidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var clasedeMedida = await _context.ClasedeMedida.SingleOrDefaultAsync(m => m.Id == id);

            if (clasedeMedida == null)
            {
                return NotFound();
            }
            var items = new List<SelectListItem>();
            items = DaBukrs(clasedeMedida.Gbukrs);
            ViewBag.DaBukrs = items.ToList();


            return View(clasedeMedida);
        }

        // POST: ClasedeMedidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Massn,Massn_desc,Massg,Massg_desc")] ClasedeMedida clasedeMedida)
        {
            clasedeMedida.Massg = clasedeMedida.Massg.PadLeft(2, '0');
            clasedeMedida.Massn = clasedeMedida.Massn.PadLeft(2, '0');
            clasedeMedida.Bukrs = clasedeMedida.Bukrs.PadLeft(4, '0');
            clasedeMedida.Gbukrs = clasedeMedida.Gbukrs.PadLeft(4, '0');
            // checar que exista Bukrs
            var items = new List<SelectListItem>();
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            items = DaBukrs(clasedeMedida.Gbukrs);
            ViewBag.DaBukrs = items.ToList();
            //check for unique key violation
            int cnt = (from m in _context.Cat1 where m.Gbukrs == clasedeMedida.Gbukrs && m.Bukrs==clasedeMedida.Bukrs
                       select m.Gbukrs).Count();
            if (cnt == 0)
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(clasedeMedida);
            }

            int cnt2 = (from m in _context.ClasedeMedida
                       where m.Gbukrs == clasedeMedida.Gbukrs && m.Bukrs == clasedeMedida.Bukrs
                       && m.Massg== clasedeMedida.Massg && m.Massn == clasedeMedida.Massn && m.Id != clasedeMedida.Id                   
                       select m.Gbukrs).Count();
            if (cnt2 != 0)
            {
                ModelState.AddModelError("Massg", "Registro Duplicado");
                return View(clasedeMedida);
            }

       

            if (id != clasedeMedida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasedeMedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasedeMedidaExists(clasedeMedida.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clasedeMedida);
        }

        // GET: ClasedeMedidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasedeMedida = await _context.ClasedeMedida
                .SingleOrDefaultAsync(m => m.Id == id);
            if (clasedeMedida == null)
            {
                return NotFound();
            }

            return View(clasedeMedida);
        }

        // POST: ClasedeMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasedeMedida = await _context.ClasedeMedida.SingleOrDefaultAsync(m => m.Id == id);
            _context.ClasedeMedida.Remove(clasedeMedida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasedeMedidaExists(int id)
        {
            return _context.ClasedeMedida.Any(e => e.Id == id);
        }

        private List<SelectListItem> DaBukrs(string gbukrsp)
        {

            // traer datos entityfram
            List<string> bukrslist = new List<string>();
            IEnumerable<string> bukrslist2 = new List<string>();
            var items = new List<SelectListItem>();
            //agregando los items a la lista

            // traer datos entityfram
            bukrslist = (from cat13 in _context.Cat1
                         where cat13.Gbukrs == gbukrsp
                         select cat13.Bukrs).ToList();
            bukrslist2 = bukrslist.Distinct();
            items.Add(new SelectListItem
            {
                Text = "Selecciona",
                Value = "Selecciona"
            });

            foreach (string lista1 in bukrslist2)
            {

                items.Add(new SelectListItem
                {
                    Text = lista1,
                    Value = lista1
                });
            }
            return (items.ToList());
            //var items = new List<SelectListItem>();
        }

    }
}
