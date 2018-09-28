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

    public class AreaPersController : Controller
    {

        private readonly ApplicationDbContext _context;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
        private string mensajito;
        public AreaPersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AreaPers
        public async Task<IActionResult> Index()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            mensajito = "";
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                return View(await _context.AreaPers.ToListAsync());
            }
            else
            {
                var x = HttpContext.Session.GetString(SessionGpoCia);
                return View(await _context.AreaPers.Where(c => c.Gbukrs == x).ToListAsync());
            }
            //return View(await _context.AreaPers.ToListAsync());
        }

        // GET: AreaPers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            mensajito = "";
            if (id == null)
            {
                return NotFound();
            }

            var areaPers = await _context.AreaPers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (areaPers == null)
            {
                return NotFound();
            }

            return View(areaPers);
        }

        // GET: AreaPers/Create
        public IActionResult Create()
        {
            ViewBag.Mensaje = mensajito;
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:AreaPers");
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

        // POST: AreaPers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Tipo_pers,Area_pers,Descrip")] AreaPers areaPers)
        {
            mensajito = "";
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            areaPers.Bukrs = areaPers.Bukrs.PadLeft(4, '0');
            areaPers.Gbukrs = areaPers.Gbukrs.PadLeft(4, '0');
            //areaPers.Area_pers = areaPers.Area_pers.PadLeft(2, '0');
            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            string Errores1 = ValidaError(areaPers.Bukrs, areaPers.Gbukrs, areaPers.Tipo_pers, areaPers.Area_pers, areaPers.Id);
            string che = Errores1.Substring(0, 1);
            if (che == "A")
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(areaPers);
            }

            if (che == "B")
            {
                ModelState.AddModelError("Area_pers", "registro duplicado");
                return View(areaPers);
            }
            if (che == "C")
            {
                ModelState.AddModelError("Tipo_pers", "No Existe");
                return View(areaPers);
            }

            if (ModelState.IsValid)
            {
                _context.Add(areaPers);
                await _context.SaveChangesAsync();
                mensajito = "Tipo Personal: " +  areaPers.Tipo_pers.ToString()+ " Área Personal: " + areaPers.Area_pers.ToString() + " Grabado con éxito";
                TempData["message"] = "Area de Personal: " + areaPers.Gbukrs + "  Cía: " + areaPers.Bukrs + " - " + areaPers.Descrip ;

                ViewBag.Mensaje = mensajito;
                return RedirectToAction(nameof(Create));
                //return RedirectToAction(nameof(Index));
            }
            return View(areaPers);
        }

        // GET: AreaPers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaPers = await _context.AreaPers.SingleOrDefaultAsync(m => m.Id == id);
            if (areaPers == null)
            {
                return NotFound();
            }

            var items = new List<SelectListItem>();
             items = DaBukrs(areaPers.Gbukrs);
               ViewBag.DaBukrs = items.ToList();

            return View(areaPers);
        }

        // POST: AreaPers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Tipo_pers,Area_pers,Descrip")] AreaPers areaPers)
        {
            mensajito = "";
            areaPers.Bukrs = areaPers.Bukrs.PadLeft(4, '0');
            areaPers.Gbukrs = areaPers.Gbukrs.PadLeft(4, '0');
           // areaPers.Area_pers = areaPers.Area_pers.PadLeft(2, '0');
            // checar que exista Bukrs

            var items = new List<SelectListItem>();
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            items = DaBukrs(areaPers.Gbukrs);
       //     if (items.Count>0)
        //    {
        //         var selected = items.Where(x => x.Value == areaPers.Bukrs).First();
        //         selected.Selected = true;
        //    }
            ViewBag.DaBukrs = items.ToList();

            if (id != areaPers.Id)
            {
                return NotFound();
            }

            string Errores1 = ValidaError(areaPers.Bukrs, areaPers.Gbukrs, areaPers.Tipo_pers, areaPers.Area_pers, areaPers.Id);
            string che = Errores1.Substring(0, 1);
            if (che == "A")
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(areaPers);
            }

            if (che == "B")
            {
                ModelState.AddModelError("Tipo_pers", "registro duplicado");
                return View(areaPers);
            }
            if (che == "C")
            {
                ModelState.AddModelError("Tipo_pers", "No Existe");
                return View(areaPers);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaPers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaPersExists(areaPers.Id))
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
            return View(areaPers);
        }

        // GET: AreaPers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            mensajito = "";
            if (id == null)
            {
                return NotFound();
            }

            var areaPers = await _context.AreaPers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (areaPers == null)
            {
                return NotFound();
            }

            return View(areaPers);
        }

        // POST: AreaPers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            mensajito = "";
            var areaPers = await _context.AreaPers.SingleOrDefaultAsync(m => m.Id == id);
            _context.AreaPers.Remove(areaPers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaPersExists(int id)
        {
            return _context.AreaPers.Any(e => e.Id == id);
        }

        private string ValidaError(string bukrs, string gbukrs, int tipoper, string areaper, int id)
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

            int cnt2 = (from m in _context.AreaPers
                        where m.Gbukrs == gbukrs && m.Bukrs == bukrs
                        && m.Area_pers == areaper && m.Tipo_pers == tipoper && m.Id != id
                        select m.Gbukrs).Count();
            if (cnt2 != 0)
            {
                errmsg = "B:Area_pers:Registro Duplicado";
                return (errmsg);
            }
            int cnt3 = (from m in _context.TipoPersonal
                        where m.Gbukrs == gbukrs && m.Bukrs == bukrs
                         && m.Tipo_pers == tipoper 
                        select m.Gbukrs).Count();
            if (cnt3 == 0)
            {
                errmsg = "C:Tipo_pers:No Existe";
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

        public JsonResult GetTipoPer(string idp)
        {
            List<TipoPersonal> DivisionList = new List<TipoPersonal>();
            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            DivisionList = (from divisiones in _context.TipoPersonal
                            where divisiones.Bukrs == idp && divisiones.Gbukrs == x
                            select divisiones).ToList();
            //inserta datos
            DivisionList.Insert(0, new TipoPersonal { Tipo_pers = 0, Descrip = "Select" });
            return Json(new SelectList(DivisionList, "Tipo_pers", "Descrip"));
        }



    }
}


