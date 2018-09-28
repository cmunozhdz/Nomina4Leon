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
    public class TipodeNominasController : Controller
    {
        private readonly ApplicationDbContext _context;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
        //public IRepositorioBukrs Repositorio { get; }
        public TipodeNominasController(ApplicationDbContext context)
        {
            _context = context;
        }
       // public TipodeNominasController(IRepositorioBukrs repositorio)
       // {
       //     Repositorio = repositorio;
       // }
       
        // GET: TipodeNominas
        public async Task<IActionResult> Index()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                return View(await _context.TipodeNomina.ToListAsync());
            }
            else
            {
                var x = HttpContext.Session.GetString(SessionGpoCia);
                return View(await _context.TipodeNomina.Where(c => c.Gbukrs == x).ToListAsync());
            }
            //return View(await _context.TipodeNomina.ToListAsync());
        }

        // GET: TipodeNominas/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var tipodeNomina = await _context.TipodeNomina
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tipodeNomina == null)
            {
                return NotFound();
            }

            return View(tipodeNomina);
        }

        // GET: TipodeNominas/Create
        public IActionResult Create()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:TipodeNominas");
                return RedirectToAction("Index", "GpoCiaGlobal");
                //return Redirect("GpoCiaGlobal/Index");
            }
            else
            {
                HttpContext.Session.SetString(SessionRegresa, "");

            }
            var items = new List<SelectListItem>();
            //  items = Repositorio.DaBukrs2(ViewBag.GpoCiaG);
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            return View();
        }

        // POST: TipodeNominas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Tipo_nom,Nomina,Descrip")] TipodeNomina tipodeNomina)
        {

            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            tipodeNomina.Bukrs = tipodeNomina.Bukrs.PadLeft(4, '0');
            tipodeNomina.Gbukrs = tipodeNomina.Gbukrs.PadLeft(4, '0');
            tipodeNomina.Nomina = tipodeNomina.Nomina.PadLeft(2, '0');

            var items = new List<SelectListItem>();
            //items = DaBukrs(ViewBag.GpoCiaG);
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            string Errores1 = ValidaError(tipodeNomina.Bukrs, tipodeNomina.Gbukrs, tipodeNomina.Tipo_nom,tipodeNomina.Nomina, tipodeNomina.Id);
            string che = Errores1.Substring(0, 1);
            if (che == "A")
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(tipodeNomina);
            }

            if (che == "B")
            {
                ModelState.AddModelError("Tipo_nom", "registro duplicado");
                return View(tipodeNomina);
            }
            if (che == "C")
            {
                ModelState.AddModelError("Tipo_nom", "Valor Inválido");
                return View(tipodeNomina);
            }



            if (ModelState.IsValid)
            {
                _context.Add(tipodeNomina);
                await _context.SaveChangesAsync();
                TempData["message"] = "Tipo de Nómina: " + tipodeNomina.Tipo_nom + "  Nómina: " + tipodeNomina.Nomina + " - " + tipodeNomina.Descrip;
                return RedirectToAction(nameof(Create));
                //return RedirectToAction(nameof(Index));
            }
            return View(tipodeNomina);
        }

        // GET: TipodeNominas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipodeNomina = await _context.TipodeNomina.SingleOrDefaultAsync(m => m.Id == id);
            if (tipodeNomina == null)
            {
                return NotFound();
            }
            var items = new List<SelectListItem>();
            items = DaBukrs(tipodeNomina.Gbukrs);
            // var selected = items.Where(x => x.Value == centrodeCostos.Bukrs).First();
            // selected.Selected = true;
            ViewBag.DaBukrs = items.ToList();
            return View(tipodeNomina);
        }

        // POST: TipodeNominas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Tipo_nom,Nomina,Descrip")] TipodeNomina tipodeNomina)
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            tipodeNomina.Bukrs = tipodeNomina.Bukrs.PadLeft(4, '0');
            tipodeNomina.Gbukrs = tipodeNomina.Gbukrs.PadLeft(4, '0');
            tipodeNomina.Nomina = tipodeNomina.Nomina.PadLeft(2, '0');

            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            string Errores1 = ValidaError(tipodeNomina.Bukrs, tipodeNomina.Gbukrs, tipodeNomina.Tipo_nom, tipodeNomina.Nomina, tipodeNomina.Id);
            string che = Errores1.Substring(0, 1);
            if (che == "A")
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(tipodeNomina);
            }

            if (che == "B")
            {
                ModelState.AddModelError("Tipo_nom", "registro duplicado");
                return View(tipodeNomina);
            }
            if (che == "C")
            {
                ModelState.AddModelError("Tipo_nom", "Valor Inválido");
                return View(tipodeNomina);
            }


            if (id != tipodeNomina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipodeNomina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipodeNominaExists(tipodeNomina.Id))
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
            return View(tipodeNomina);
        }

        // GET: TipodeNominas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipodeNomina = await _context.TipodeNomina
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tipodeNomina == null)
            {
                return NotFound();
            }

            return View(tipodeNomina);
        }

        // POST: TipodeNominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipodeNomina = await _context.TipodeNomina.SingleOrDefaultAsync(m => m.Id == id);
            _context.TipodeNomina.Remove(tipodeNomina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipodeNominaExists(int id)
        {
            return _context.TipodeNomina.Any(e => e.Id == id);
        }

        private string ValidaError(string bukrs, string gbukrs, string tiponomina,string nomina, int id)
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

            int cnt2 = (from m in _context.TipodeNomina
                        where m.Gbukrs == gbukrs && m.Bukrs == bukrs
                        && m.Tipo_nom == tiponomina && m.Nomina == nomina && m.Id != id
                        select m.Gbukrs).Count();
            if (cnt2 != 0)
            {
                errmsg = "B:Cent_cost:Registro Duplicado";
                return (errmsg);
            }
            if (tiponomina == "")
            {
                errmsg = "C:Cent_cost:No puede ser nulo";

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
