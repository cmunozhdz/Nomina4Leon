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

namespace ASPNETCORERoleManagement
{
    [Authorize(Roles = "Admin")] //Fija los permisos.
    public class TipoObjsController : Controller
    {
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";

        private readonly ApplicationDbContext _context;

        public TipoObjsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoObjs
        public async Task<IActionResult> Index()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);

            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                //Obliga a fijar la socidad principal

                HttpContext.Session.SetString(SessionRegresa, "Index:TipoObjs");
                return RedirectToAction("Index", "GpoCiaGlobal");
            }
            else
            {
                //Muestra las competencias de la sociedad actual.
                var x = HttpContext.Session.GetString(SessionGpoCia);
                // GpoCiaCtrl = HttpContext.Session.GetString(SessionGpoCia);
                  
                return View(await _context.TipoObj.Where(a => a.gbukrs == x).ToListAsync());

            }



            

        }

        // GET: TipoObjs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoObj = await _context.TipoObj
                .SingleOrDefaultAsync(m => m.TipoObjId == id);
            if (tipoObj == null)
            {
                return NotFound();
            }

            return View(tipoObj);
        }

        // GET: TipoObjs/Create
        public IActionResult Create()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:TipoObjs");
                return RedirectToAction("Index", "GpoCiaGlobal");

            }
            else
            {
                HttpContext.Session.SetString(SessionRegresa, "");

                BukrsRepositorioEF BEF = new BukrsRepositorioEF(_context);
                ViewBag.Bukrs = BEF.DaBukrs2(ViewBag.GpoCiaG);
                return View();
            }


            
        }

        // POST: TipoObjs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoObjId,gbukrs,bukrs,Descripcion")] TipoObj tipoObj)
        {
            //Valida que no haya registros duplicados
            if (_context.TipoObj.Any(c => c.TipoObjId ==tipoObj.TipoObjId))
            {
                //el registro ya existe provoca un error en la validación
                ModelState.AddModelError("TipoObjId", "El registro ya existe.");
                ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);

                if (ViewBag.GpoCiaG == null)
                {
                    HttpContext.Session.SetString(SessionRegresa, "Create:TipoObjs");
                    return RedirectToAction("Index", "GpoCiaGlobal");

                }
                else
                {
                    HttpContext.Session.SetString(SessionRegresa, "");

                    BukrsRepositorioEF BEF = new BukrsRepositorioEF(_context);
                    ViewBag.Bukrs = BEF.DaBukrs2(ViewBag.GpoCiaG);
                    return View();
                }

            }
            else
            {
                //Envia los cambios
                if (ModelState.IsValid)
                {
                    _context.Add(tipoObj);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tipoObj);
            }

            
        }

        // GET: TipoObjs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Edit:TipoObjs");
                return RedirectToAction("Index", "GpoCiaGlobal");

            }
            else
            {
                HttpContext.Session.SetString(SessionRegresa, "");

                BukrsRepositorioEF BEF = new BukrsRepositorioEF(_context);
                ViewBag.Bukrs = BEF.DaBukrs2(ViewBag.GpoCiaG);
                
                var tipoObj = await _context.TipoObj.SingleOrDefaultAsync(m => m.TipoObjId == id);
                if (tipoObj == null)
                {
                    return NotFound();
                }
                return View(tipoObj);
            }

        }

        // POST: TipoObjs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TipoObjId,gbukrs,bukrs,Descripcion")] TipoObj tipoObj)
        {
            if (id != tipoObj.TipoObjId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoObj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoObjExists(tipoObj.TipoObjId))
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
            return View(tipoObj);
        }

        // GET: TipoObjs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoObj = await _context.TipoObj
                .SingleOrDefaultAsync(m => m.TipoObjId == id);
            if (tipoObj == null)
            {
                return NotFound();
            }

            return View(tipoObj);
        }

        // POST: TipoObjs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tipoObj = await _context.TipoObj.SingleOrDefaultAsync(m => m.TipoObjId == id);
            _context.TipoObj.Remove(tipoObj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoObjExists(string id)
        {
            return _context.TipoObj.Any(e => e.TipoObjId == id);
        }
    }
}
