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
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using ASPNETCORERoleManagement.Services;

namespace ASPNETCORERoleManagement.Controllers
{
    [Authorize(Roles = "Admin")]

    public class SubdivisionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositorioBukrs _bukrs;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
        public SubdivisionsController(ApplicationDbContext context,IRepositorioBukrs bukrs)
        {
            _context = context;
            _bukrs = bukrs;
        }

        // GET: Subdivisions
        public async Task<IActionResult> Index()
        {
            ViewBag.Message = "";
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                return View(await _context.Subdivision.ToListAsync());
            }
            else
            {
                var x = HttpContext.Session.GetString(SessionGpoCia);
                return View(await _context.Subdivision.Where(c => c.Gbukrs == x).ToListAsync());
            }
           // return View(await _context.Subdivision.ToListAsync());
        }

        // GET: Subdivisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.showSuccessAlert = false;
            ViewBag.Message = "";
            if (id == null)
            {
                return NotFound();
            }

            var subdivision = await _context.Subdivision
                .SingleOrDefaultAsync(m => m.Id == id);
            if (subdivision == null)
            {
                return NotFound();
            }

            return View(subdivision);
        }

        // GET: Subdivisions/Create
        public IActionResult Create()
        {

           // ViewBag.Message = "";
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            List<Divis> divislist = new List<Divis>();
            divislist = (from divis2 in _context.Divis
                           select divis2).ToList();
            //agregando los items a la lista
            divislist.Insert(0, new Divis { Id = 0, Descrip = "Select" });
            //asignar category list to viewbag
            ViewBag.ListofCategory = divislist;
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:Subdivisions");
                return RedirectToAction("Index", "GpoCiaGlobal");
                //return Redirect("GpoCiaGlobal/Index");
            }
            else
            {
                HttpContext.Session.SetString(SessionRegresa, "");

            }
            var items = new List<SelectListItem>();
            //items = DaBukrs(ViewBag.GpoCiaG);
            items = _bukrs.DaBukrs2(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();

            return View();
        }

        // POST: Subdivisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Divi,Subdivis,Descrip")] Subdivision subdivision)
        {
            // mi validacion
      
            subdivision.Bukrs = subdivision.Bukrs.PadLeft(4, '0');
            subdivision.Gbukrs = subdivision.Gbukrs.PadLeft(4, '0');
            subdivision.Subdivis = subdivision.Subdivis.PadLeft(4, '0');
            ViewBag.Message = "";
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            // QUE EXISTA LA DIVISION, que exista Gbukrs y Bukrs  y que no exista la subdivision
            var items = new List<SelectListItem>();
            items = _bukrs.DaBukrs2(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            int cnt = (from m in _context.Cat1
                       where m.Gbukrs == subdivision.Gbukrs && m.Bukrs == subdivision.Bukrs
                       select m.Gbukrs).Count();
            if (cnt == 0)
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(subdivision);
            }
            int cnt2 = (from m in _context.Divis
                        where m.Gbukrs == subdivision.Gbukrs && m.Bukrs == subdivision.Bukrs
                        && m.Divi == subdivision.Divi && m.Id != subdivision.Id
                        select m.Gbukrs).Count();
            if (cnt2 == 0)
            {
                ModelState.AddModelError("Divi", "No existe ese registro");
                return View(subdivision);
            }
            int cnt3 = (from m in _context.Subdivision
                        where m.Gbukrs == subdivision.Gbukrs && m.Bukrs == subdivision.Bukrs
                        && m.Divi == subdivision.Divi && m.Subdivis == subdivision.Subdivis && m.Id != subdivision.Id
                        select m.Gbukrs).Count();
            if (cnt3 != 0)
            {
                ModelState.AddModelError("Subdivis", "Registro Duplicado");
                return View(subdivision);
            }





            if (ModelState.IsValid)
            {
                _context.Add(subdivision);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Registro agregado con éxito";
                TempData["message"] = subdivision.Gbukrs + "  Cía: " + subdivision.Bukrs + " - " + subdivision.Descrip;

                return RedirectToAction(nameof(Create));

                //return RedirectToAction(nameof(Index));
            }
            return View(subdivision);
        }

        // GET: Subdivisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Message="";
           
            if (id == null)
            {
                return NotFound();
            }

            var subdivision = await _context.Subdivision.SingleOrDefaultAsync(m => m.Id == id);
            if (subdivision == null)
            {
                return NotFound();
            }
            var items = new List<SelectListItem>();
            items = _bukrs.DaBukrs2(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            return View(subdivision);
        }

        // POST: Subdivisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Divi,Subdivis,Descrip")] Subdivision subdivision)
        {
            ViewBag.Message = "";
            subdivision.Bukrs = subdivision.Bukrs.PadLeft(4, '0');
            subdivision.Gbukrs = subdivision.Gbukrs.PadLeft(4, '0');
            subdivision.Subdivis = subdivision.Subdivis.PadLeft(4, '0');


            ViewBag.Message = "";
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            // QUE EXISTA LA DIVISION, que exista Gbukrs y Bukrs  y que no exista la subdivision
            var items = new List<SelectListItem>();
//            items = DaBukrs(ViewBag.GpoCiaG);
            items = _bukrs.DaBukrs2(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            int cnt = (from m in _context.Cat1
                       where m.Gbukrs == subdivision.Gbukrs && m.Bukrs == subdivision.Bukrs
                       select m.Gbukrs).Count();
            if (cnt == 0)
            {
                ModelState.AddModelError("Bukrs", "no existe esa Compañía");
                return View(subdivision);
            }
            int cnt2 = (from m in _context.Divis
                        where m.Gbukrs == subdivision.Gbukrs && m.Bukrs == subdivision.Bukrs
                        && m.Divi == subdivision.Divi && m.Id != subdivision.Id
                        select m.Gbukrs).Count();
            if (cnt2 == 0)
            {
                ModelState.AddModelError("Divi", "No existe ese registro");
                return View(subdivision);
            }
            int cnt3 = (from m in _context.Subdivision
                        where m.Gbukrs == subdivision.Gbukrs && m.Bukrs == subdivision.Bukrs
                        && m.Divi == subdivision.Divi && m.Subdivis == subdivision.Subdivis && m.Id != subdivision.Id
                        select m.Gbukrs).Count();
            if (cnt3 != 0)
            {
                ModelState.AddModelError("Subdivis", "Registro Duplicado");
                return View(subdivision);
            }




            if (id != subdivision.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subdivision);
                    await _context.SaveChangesAsync();
                    ViewBag.Message="";

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubdivisionExists(subdivision.Id))
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
            return View(subdivision);
        }

        // GET: Subdivisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Message = "";

            if (id == null)
            {
                return NotFound();
            }

            var subdivision = await _context.Subdivision
                .SingleOrDefaultAsync(m => m.Id == id);
            if (subdivision == null)
            {
                return NotFound();
            }

            return View(subdivision);
        }

        // POST: Subdivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subdivision = await _context.Subdivision.SingleOrDefaultAsync(m => m.Id == id);
            _context.Subdivision.Remove(subdivision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubdivisionExists(int id)
        {
            return _context.Subdivision.Any(e => e.Id == id);
        }

    
        public JsonResult GetDivisions(string idp)
        {
           List<Divis> DivisionList = new List<Divis>();
            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
           // DivisionList = (from divisiones in _context.Divis
                       //     where divisiones.Bukrs == idp && divisiones.Gbukrs == x
                      //      select divisiones).ToList();
            //inserta datos
           // DivisionList.Insert(0, new Divis { Divi = "0", Descrip = "Select" });
            DivisionList = _bukrs.GetDivisions(idp, x);
            return Json(new SelectList(DivisionList, "Divi", "Descrip"));
        }




    }
}
