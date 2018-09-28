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

namespace ASPNETCORERoleManagement.Controllers
{
	 [Authorize(Roles = "Admin")]
    public class Estatus_stat2Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";

        public Estatus_stat2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estatus_stat2
        public async Task<IActionResult> Index()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                return View(await _context.Estatus_Stat2.ToListAsync());
            }
            else
            {
                var x = HttpContext.Session.GetString(SessionGpoCia);
                return View(await _context.Estatus_Stat2.Where(c => c.Gbukrs==x).ToListAsync());
            }
        }

        // GET: Estatus_stat2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estatus_stat2 = await _context.Estatus_Stat2
                .SingleOrDefaultAsync(m => m.Id == id);
            if (estatus_stat2 == null)
            { 

                return NotFound();
            }

            return View(estatus_stat2);
        }

        // GET: Estatus_stat2/Create
        public IActionResult Create()
        {
        	
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG==null )
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:Estatus_stat2");
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

            return View();
        }

        // POST: Estatus_stat2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Estatus,Desc")] Estatus_stat2 estatus_stat2)
        {
            // mi validacion
            estatus_stat2.Bukrs = estatus_stat2.Bukrs.PadLeft(4, '0');
            estatus_stat2.Gbukrs = estatus_stat2.Gbukrs.PadLeft(4, '0');
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            if (ModelState.IsValid)
            {
                //checar si ya se dio de alta uno igual

                int cnt = (from m in _context.Cat1
                           where m.Gbukrs == estatus_stat2.Gbukrs && m.Bukrs == estatus_stat2.Bukrs
                           select m.Gbukrs).Count();
                if (cnt == 0)
                {
                    ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                    return View(estatus_stat2);
                }

                int cnt2 = (from m in _context.Estatus_Stat2
                            where m.Gbukrs == estatus_stat2.Gbukrs && m.Bukrs == estatus_stat2.Bukrs
                            && m.Estatus == estatus_stat2.Estatus && m.Id != estatus_stat2.Id
                            select m.Gbukrs).Count();
                if (cnt2 != 0)
                {
                    ModelState.AddModelError("Estatus", "Registro Duplicado");

                    return View(estatus_stat2);
                }
                //inserta datos
            }	
        	
        	
        	/// aqui lo original
            if (ModelState.IsValid)
            {
                _context.Add(estatus_stat2);
                await _context.SaveChangesAsync();
                TempData["message"] = estatus_stat2.Gbukrs + "  Cía: " + estatus_stat2.Bukrs + " - " + estatus_stat2.Desc;

                return RedirectToAction(nameof(Create));
                //return RedirectToAction(nameof(Index));
            }
            return View(estatus_stat2);
        }

        // GET: Estatus_stat2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var estatus_stat2 = await _context.Estatus_Stat2.SingleOrDefaultAsync(m => m.Id == id);
            if (estatus_stat2 == null)
            {
                return NotFound();
            }
            var items = new List<SelectListItem>();
            items = DaBukrs(estatus_stat2.Gbukrs);
            ViewBag.DaBukrs = items.ToList();

            return View(estatus_stat2);
        }

        // POST: Estatus_stat2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Estatus,Desc")] Estatus_stat2 estatus_stat2)
        {
            estatus_stat2.Bukrs = estatus_stat2.Bukrs.PadLeft(4, '0');
            estatus_stat2.Gbukrs = estatus_stat2.Gbukrs.PadLeft(4, '0');
            ViewBag.GpoCiaG = estatus_stat2.Gbukrs;
            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();

            if (id != estatus_stat2.Id)
            {
                return NotFound();
            }
            //checar si ya se dio de alta uno igual
            int cnt = (from m in _context.Cat1
                       where m.Gbukrs == estatus_stat2.Gbukrs && m.Bukrs == estatus_stat2.Bukrs
                       select m.Gbukrs).Count();
            if (cnt == 0)
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(estatus_stat2);
            }

            int cnt2 = (from m in _context.Estatus_Stat2
                        where m.Gbukrs == estatus_stat2.Gbukrs && m.Bukrs == estatus_stat2.Bukrs
                        && m.Estatus == estatus_stat2.Estatus && m.Id != estatus_stat2.Id
                        select m.Gbukrs).Count();
            if (cnt2 != 0)
            {
                ModelState.AddModelError("Estatus", "Registro Duplicado");
                return View(estatus_stat2);
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estatus_stat2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Estatus_stat2Exists(estatus_stat2.Id))
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
            return View(estatus_stat2);
        }

        // GET: Estatus_stat2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estatus_stat2 = await _context.Estatus_Stat2
                .SingleOrDefaultAsync(m => m.Id == id);
            if (estatus_stat2 == null)
            {
                return NotFound();
            }

            return View(estatus_stat2);
        }

        // POST: Estatus_stat2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estatus_stat2 = await _context.Estatus_Stat2.SingleOrDefaultAsync(m => m.Id == id);
            _context.Estatus_Stat2.Remove(estatus_stat2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Estatus_stat2Exists(int id)
        {
            return _context.Estatus_Stat2.Any(e => e.Id == id);
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
