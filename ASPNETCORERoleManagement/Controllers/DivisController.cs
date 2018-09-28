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
    public class DivisController : Controller
    {

        private readonly ApplicationDbContext _context;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";

        public DivisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Divis
        public async Task<IActionResult> Index()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                return View(await _context.Divis.ToListAsync());
            }
            else
            {
                var x = HttpContext.Session.GetString(SessionGpoCia);
                return View(await _context.Divis.Where(c => c.Gbukrs == x).ToListAsync());
            }
      
        }

        // GET: Divis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divis = await _context.Divis
                .SingleOrDefaultAsync(m => m.Id == id);
            if (divis == null)
            {
                return NotFound();
            }

            return View(divis);
        }

        // GET: Divis/Create
        public IActionResult Create()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:Divis");
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

        // POST: Divis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Divi,Descrip")] Divis divis)
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            divis.Bukrs = divis.Bukrs.PadLeft(4, '0');
            divis.Gbukrs = divis.Gbukrs.PadLeft(4, '0');
            divis.Divi = divis.Divi.PadLeft(4, '0');
            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            int cnt = (from m in _context.Cat1
                       where m.Gbukrs == divis.Gbukrs && m.Bukrs == divis.Bukrs
                       select m.Gbukrs).Count();
            if (cnt == 0)
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(divis);
            }

            int cnt2 = (from m in _context.Divis
                        where m.Gbukrs == divis.Gbukrs && m.Bukrs == divis.Bukrs
                        && m.Divi == divis.Divi && m.Id != divis.Id
                        select m.Gbukrs).Count();
            if (cnt2 != 0)
            {
                ModelState.AddModelError("Divi", "Registro Duplicado");
                return View(divis);
            }



            if (ModelState.IsValid)
            {
                _context.Add(divis);
                await _context.SaveChangesAsync();
                TempData["message"] =  divis.Gbukrs + "  Cía: " + divis.Bukrs + " - " + divis.Descrip ;
                return RedirectToAction(nameof(Create));
                //return RedirectToAction(nameof(Index));
            }
            return View(divis);
        }

        // GET: Divis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divis = await _context.Divis.SingleOrDefaultAsync(m => m.Id == id);
            if (divis == null)
            {
                return NotFound();
            }
            var items = new List<SelectListItem>();
            items = DaBukrs(divis.Gbukrs);
            ViewBag.DaBukrs = items.ToList();
            return View(divis);
        }

        // POST: Divis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Divi,Descrip")] Divis divis)
        {
            divis.Bukrs = divis.Bukrs.PadLeft(4, '0');
            divis.Gbukrs = divis.Gbukrs.PadLeft(4, '0');
            divis.Divi = divis.Divi.PadLeft(4, '0');
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            var items = new List<SelectListItem>();
            items = DaBukrs(divis.Gbukrs);
            ViewBag.DaBukrs = items.ToList();
            int cnt = (from m in _context.Cat1
                       where m.Gbukrs == divis.Gbukrs && m.Bukrs == divis.Bukrs
                       select m.Gbukrs).Count();
            if (cnt == 0)
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(divis);
            }

            int cnt2 = (from m in _context.Divis
                        where m.Gbukrs == divis.Gbukrs && m.Bukrs == divis.Bukrs
                        && m.Divi == divis.Divi  && m.Id != divis.Id
                        select m.Gbukrs).Count();
            if (cnt2 != 0)
            {
                ModelState.AddModelError("Divi", "Registro Duplicado");
                return View(divis);
            }


            if (id != divis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(divis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivisExists(divis.Id))
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
            return View(divis);
        }

        // GET: Divis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divis = await _context.Divis
                .SingleOrDefaultAsync(m => m.Id == id);
            if (divis == null)
            {
                return NotFound();
            }

            return View(divis);
        }

        // POST: Divis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var divis = await _context.Divis.SingleOrDefaultAsync(m => m.Id == id);
            _context.Divis.Remove(divis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivisExists(int id)
        {
            return _context.Divis.Any(e => e.Id == id);
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
