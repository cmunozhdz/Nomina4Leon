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
    public class CentrodeCostosController : Controller
    {
        private readonly ApplicationDbContext _context;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
        public CentrodeCostosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CentrodeCostos
        public async Task<IActionResult> Index()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                return View(await _context.CentrodeCostos.ToListAsync());
            }
            else
            {
                var x = HttpContext.Session.GetString(SessionGpoCia);
                return View(await _context.CentrodeCostos.Where(c => c.Gbukrs == x).ToListAsync());
            }
            //return View(await _context.CentrodeCostos.ToListAsync());
        }

        // GET: CentrodeCostos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centrodeCostos = await _context.CentrodeCostos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (centrodeCostos == null)
            {
                return NotFound();
            }

            return View(centrodeCostos);
        }

        // GET: CentrodeCostos/Create
        public IActionResult Create()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:CentrodeCostos");
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

        // POST: CentrodeCostos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Cent_cost,Descrip")] CentrodeCostos centrodeCostos)
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            centrodeCostos.Bukrs = centrodeCostos.Bukrs.PadLeft(4, '0');
            centrodeCostos.Gbukrs = centrodeCostos.Gbukrs.PadLeft(4, '0');
            //centrodeCostos.Cent_cost = centrodeCostos.Cent_cost.PadLeft(10, '0');

            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            string Errores1 = ValidaError(centrodeCostos.Bukrs, centrodeCostos.Gbukrs, centrodeCostos.Cent_cost, centrodeCostos.Id);
            string che = Errores1.Substring(0, 1);
            if (che == "A")
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(centrodeCostos);
            }

            if (che == "B")
            {
                ModelState.AddModelError("Cent_cost", "registro duplicado");
                return View(centrodeCostos);
            }
            if (che == "C")
            {
                ModelState.AddModelError("Cent_cost", "Valor Inválido");
                return View(centrodeCostos);
            }
            if (ModelState.IsValid)
            {
                _context.Add(centrodeCostos);
                await _context.SaveChangesAsync();
                //ModelState.AddModelError("", "Registro Agregado con éxito");
                TempData["message"] =  centrodeCostos.Gbukrs + "  Cía: " + centrodeCostos.Bukrs + " - " + centrodeCostos.Descrip;
                return RedirectToAction(nameof(Create));
                //return RedirectToAction(nameof(Index));
            }
            return View(centrodeCostos);
        }

        // GET: CentrodeCostos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centrodeCostos = await _context.CentrodeCostos.SingleOrDefaultAsync(m => m.Id == id);
            if (centrodeCostos == null)
            {
                return NotFound();
            }
            var items = new List<SelectListItem>();
            items = DaBukrs(centrodeCostos.Gbukrs);
           // var selected = items.Where(x => x.Value == centrodeCostos.Bukrs).First();
           // selected.Selected = true;
            ViewBag.DaBukrs = items.ToList();
            return View(centrodeCostos);
        }

        // POST: CentrodeCostos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Cent_cost,Descrip")] CentrodeCostos centrodeCostos)
        {
            centrodeCostos.Bukrs = centrodeCostos.Bukrs.PadLeft(4, '0');
            centrodeCostos.Gbukrs = centrodeCostos.Gbukrs.PadLeft(4, '0');
            //centrodeCostos.Cent_cost = centrodeCostos.Cent_cost.PadLeft(10, '0');

            // checar que exista Bukrs
            var items = new List<SelectListItem>();
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            items = DaBukrs(centrodeCostos.Gbukrs);
//            var selected = items.Where(x => x.Value == centrodeCostos.Bukrs).First();
 //           selected.Selected = true;
            ViewBag.DaBukrs = items.ToList();
            string Errores = ValidaError(centrodeCostos.Bukrs, centrodeCostos.Gbukrs, centrodeCostos.Cent_cost, centrodeCostos.Id);
            if (Errores.Substring(0, 1) == "A")
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(centrodeCostos);
            }

            if (Errores.Substring(0, 1) == "B")
            {
                ModelState.AddModelError("Cent_cost", "registro duplicado");
                return View(centrodeCostos);
            }
            if (Errores.Substring(0, 1) == "C")
            {
                ModelState.AddModelError("Cent_cost", "Valor inválido");
                return View(centrodeCostos);
            }


            if (id != centrodeCostos.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centrodeCostos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentrodeCostosExists(centrodeCostos.Id))
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
            return View(centrodeCostos);
        }

        // GET: CentrodeCostos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centrodeCostos = await _context.CentrodeCostos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (centrodeCostos == null)
            {
                return NotFound();
            }

            return View(centrodeCostos);
        }

        // POST: CentrodeCostos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centrodeCostos = await _context.CentrodeCostos.SingleOrDefaultAsync(m => m.Id == id);
            _context.CentrodeCostos.Remove(centrodeCostos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentrodeCostosExists(int id)
        {
            return _context.CentrodeCostos.Any(e => e.Id == id);
        }

        private string ValidaError(string bukrs, string gbukrs, string centro, int id)
        {
     
            int cnt = (from m in _context.Cat1
                       where m.Gbukrs == gbukrs && m.Bukrs == bukrs
                       select m.Gbukrs).Count();
            string errmsg = "";
            if (cnt == 0)
            {
                errmsg = "A:Bukrs:No existe esa Compañía";
                return (errmsg);
            }

            int cnt2 = (from m in _context.CentrodeCostos
                        where m.Gbukrs == gbukrs && m.Bukrs == bukrs
                        && m.Cent_cost == centro &&   m.Id != id
                        select m.Gbukrs).Count();
            if (cnt2 != 0)
            {
                errmsg = "B:Cent_cost:Registro Duplicado";
                return (errmsg);
            }
            if (centro == "0" || centro == "00")
            {
                errmsg = "C:Cent_cost:No puede ser 0";

            }
            return ("Z");
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
