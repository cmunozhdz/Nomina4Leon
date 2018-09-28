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

    public class TipoPersonalsController : Controller
    {
        private readonly ApplicationDbContext _context;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
        public TipoPersonalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoPersonals
        public async Task<IActionResult> Index()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                return View(await _context.TipoPersonal.ToListAsync());
            }
            else
            {
                var x = HttpContext.Session.GetString(SessionGpoCia);
                return View(await _context.TipoPersonal.Where(c => c.Gbukrs == x).ToListAsync());
            }
           // return View(await _context.TipoPersonal.ToListAsync());
        }

        // GET: TipoPersonals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPersonal = await _context.TipoPersonal
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tipoPersonal == null)
            {
                return NotFound();
            }

            return View(tipoPersonal);
        }

        // GET: TipoPersonals/Create
        public IActionResult Create()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:TipoPersonals");
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

        // POST: TipoPersonals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Tipo_pers,Descrip")] TipoPersonal tipoPersonal)
        {
            ViewBag.Mensaje = "";
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            tipoPersonal.Bukrs = tipoPersonal.Bukrs.PadLeft(4, '0');
            tipoPersonal.Gbukrs = tipoPersonal.Gbukrs.PadLeft(4, '0');
            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            string Errores1 = ValidaError(tipoPersonal.Bukrs, tipoPersonal.Gbukrs, tipoPersonal.Tipo_pers, tipoPersonal.Id);
            string che = Errores1.Substring(0, 1);
            if (che == "A")
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(tipoPersonal);
            }

            if (che == "B")
            {
                ModelState.AddModelError("Tipo_pers", "registro duplicado");
                return View(tipoPersonal);
            }


            if (ModelState.IsValid)
            {
                _context.Add(tipoPersonal);
                await _context.SaveChangesAsync();
                ViewBag.Mensaje = "Tipo Personal: " + tipoPersonal.Tipo_pers.ToString() +" Grabado con éxito";
                TempData["message"] = tipoPersonal.Gbukrs + "  Cía: " + tipoPersonal.Bukrs + " - " + tipoPersonal .Descrip;

                return RedirectToAction(nameof(Index));
            }
            return View(tipoPersonal);
        }

        // GET: TipoPersonals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPersonal = await _context.TipoPersonal.SingleOrDefaultAsync(m => m.Id == id);
            if (tipoPersonal == null)
            {
                return NotFound();
            }
            var items = new List<SelectListItem>();
            items = DaBukrs(tipoPersonal.Gbukrs);
           // var selected = items.Where(x => x.Value == tipoPersonal.Bukrs).First();
           // selected.Selected = true;
            ViewBag.DaBukrs = items.ToList();
            return View(tipoPersonal);
        }

        // POST: TipoPersonals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Tipo_pers,Descrip")] TipoPersonal tipoPersonal)
        {

            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            tipoPersonal.Bukrs = tipoPersonal.Bukrs.PadLeft(4, '0');
            tipoPersonal.Gbukrs = tipoPersonal.Gbukrs.PadLeft(4, '0');
            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            string Errores1 = ValidaError(tipoPersonal.Bukrs, tipoPersonal.Gbukrs, tipoPersonal.Tipo_pers, tipoPersonal.Id);
            string che = Errores1.Substring(0, 1);
            if (che == "A")
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(tipoPersonal);
            }

            if (che == "B")
            {
                ModelState.AddModelError("Tipo_pers", "registro duplicado");
                return View(tipoPersonal);
            }


            if (id != tipoPersonal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPersonal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPersonalExists(tipoPersonal.Id))
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
            return View(tipoPersonal);
        }

        // GET: TipoPersonals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPersonal = await _context.TipoPersonal
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tipoPersonal == null)
            {
                return NotFound();
            }

            return View(tipoPersonal);
        }

        // POST: TipoPersonals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPersonal = await _context.TipoPersonal.SingleOrDefaultAsync(m => m.Id == id);
            _context.TipoPersonal.Remove(tipoPersonal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPersonalExists(int id)
        {
            return _context.TipoPersonal.Any(e => e.Id == id);
        }

        private string ValidaError(string bukrs, string gbukrs, int tipoper, int id)
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

            int cnt2 = (from m in _context.TipoPersonal
                        where m.Gbukrs == gbukrs && m.Bukrs == bukrs
                        && m.Tipo_pers == tipoper && m.Id != id
                        select m.Gbukrs).Count();
            if (cnt2 != 0)
            {
                errmsg = "B:Tipo_pers:Tipo";
                return (errmsg);
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
