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
    [Authorize(Roles = "Admin")] //Fija los permisos.
    public class CompetenciasController : Controller
    {
        private readonly ApplicationDbContext _context;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";


        public CompetenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        private Boolean EsValidoGcia(string pvalue )
        {
            //Lee si se ha fijado la compañia
            //En caso contrario redirecciona para que la fijes.
            //Si es correcta aplica el filtro.
            ViewBag.gburks = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, pvalue );
                return false;
                
            }
            else {
                HttpContext.Session.SetString(SessionRegresa, "");
                return true;

            }


        }

        // GET: Competencias
        public async Task<IActionResult> Index()
        {
            
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                //Obliga a fijar la socidad principal

                HttpContext.Session.SetString(SessionRegresa, "Index:Competencias");
                return RedirectToAction("Index", "GpoCiaGlobal");
            }
            else
            {
                //Muestra las competencias de la sociedad actual.
                var x = HttpContext.Session.GetString(SessionGpoCia);
               // GpoCiaCtrl = HttpContext.Session.GetString(SessionGpoCia);

                return View(await _context.Competencias.Where(c => c.gbukrs == x).ToListAsync());

            }




        }

        // GET: Competencias/Details/5
        public async Task<IActionResult> Details(string id, string gbukrs, string bukrs)
        {
            if (id == null || gbukrs == null || bukrs == null )
            {
                return NotFound();
            }

            var competencias = await _context.Competencias
                .SingleOrDefaultAsync(m => m.Id_Competencia == id && m.gbukrs == gbukrs && m.bukrs == bukrs  );
            if (competencias == null)
            {
                return NotFound();
            }

            return View(competencias);
        }

        // GET: Competencias/Create
        public IActionResult Create()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:Competencias");
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

        // POST: Competencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Competencia,gbukrs,bukrs,Competencias_Desc,Generico")] Competencias competencias)
        {
            //Verifica que no haya registros duplicados.
            if (_context.Competencias.Any(a=>a.Id_Competencia==competencias.Id_Competencia  && a.gbukrs == competencias.gbukrs && a.bukrs ==competencias.bukrs ))
            {
                ModelState.AddModelError("Id_Competencia", "El registro ya existe");
                ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
                if (ViewBag.GpoCiaG == null)
                {
                    HttpContext.Session.SetString(SessionRegresa, "Create:Competencias");
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
                if (ModelState.IsValid)
                {
                    _context.Add(competencias);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(competencias);
            }

            
        }

        // GET: Competencias/Edit/5
        public async Task<IActionResult> Edit(string id,string gbukrs, string bukrs)
        {
            if (id == null || gbukrs == null || bukrs == null)
            {
                return NotFound();
            }

            var competencias = await _context.Competencias.SingleOrDefaultAsync(m => m.Id_Competencia == id && m.bukrs== bukrs && m.gbukrs == gbukrs);
            if (competencias == null)
            {
                return NotFound();
            }
            return View(competencias);
        }

        // POST: Competencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, string gbukrs, string bukrs , [Bind("Id_Competencia,gbukrs,bukrs,Competencias_Desc,Generico")] Competencias competencias)
        {
            if (id != competencias.Id_Competencia || gbukrs != competencias.gbukrs || bukrs !=competencias.bukrs )
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competencias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!CompetenciasExists(competencias.Id_Competencia,competencias.gbukrs,competencias.bukrs))
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
            return View(competencias);
        }

        // GET: Competencias/Delete/5
        public async Task<IActionResult> Delete(string id, string gbukrs, string bukrs)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencias = await _context.Competencias
                .SingleOrDefaultAsync(m => m.Id_Competencia == id && m.bukrs == bukrs && m.gbukrs == gbukrs);
            if (competencias == null)
            {
                return NotFound();
            }

            return View(competencias);
        }

        // POST: Competencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, string gbukrs, string bukrs)
        {
            var competencias = await _context.Competencias.SingleOrDefaultAsync(m => m.Id_Competencia == id && m.bukrs == bukrs && m.gbukrs == gbukrs);
            _context.Competencias.Remove(competencias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenciasExists(string id,string gbukrs, string bukrs )
        {
            return _context.Competencias.Any(e => e.Id_Competencia == id && e.bukrs==bukrs  && e.gbukrs== gbukrs  ) ;
        }
    }
}
