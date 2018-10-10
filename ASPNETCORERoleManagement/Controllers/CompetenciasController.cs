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
using ASPNETCORERoleManagement.Services
;
namespace ASPNETCORERoleManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompetenciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetenciasController(ApplicationDbContext context)
        {
            _context = context;
        }
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";

        // GET: Competencias
        public async Task<IActionResult> Index()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                HttpContext.Session.SetString(SessionRegresa, "Index:Competencias");
                return RedirectToAction("Index", "GpoCiaGlobal");

            }
            else
            {
                var x = HttpContext.Session.GetString(SessionGpoCia);
                
                return View(await _context.Competencias.ToListAsync());
            }

            

        }

        // GET: Competencias/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencias = await _context.Competencias
                .SingleOrDefaultAsync(m => m.Id_Competencia == id);
            if (competencias == null)
            {
                return NotFound();
            }

            return View(competencias);
        }

        // GET: Competencias/Create
        public IActionResult Create()
        {
            //Actualiza el combo de seleccion.
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
        public async Task<IActionResult> Create([Bind("Id_Competencia,Competencias_Desc,Generico,bukrs,gbukrs")] Competencias competencias)
        {
            

            if (_context.Competencias.Any(a => a.Id_Competencia == competencias.Id_Competencia)) {
                //Valida que no haya registros duplicados y de ser asi provoca un error.
                ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
                if (ViewBag.GpoCiaG == null)
                {
                    HttpContext.Session.SetString(SessionRegresa, "Create:Competencias");
                    return RedirectToAction("Index", "GpoCiaGlobal");

                }
                else {
                    BukrsRepositorioEF BEF = new BukrsRepositorioEF(_context);
                    ViewBag.Bukrs = BEF.DaBukrs2(ViewBag.GpoCiaG);
                    ModelState.AddModelError("Id_Competencia", "Registro ya existe");


                }

                

            }


            if (ModelState.IsValid)
            {

                _context.Add(competencias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competencias);
        }

        // GET: Competencias/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencias = await _context.Competencias.SingleOrDefaultAsync(m => m.Id_Competencia == id);
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
        public async Task<IActionResult> Edit(string id, [Bind("Id_Competencia,Competencias_Desc,Generico,bukrs,gbukrs")] Competencias competencias)
        {
            if (id != competencias.Id_Competencia)
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
                    if (!CompetenciasExists(competencias.Id_Competencia))
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
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencias = await _context.Competencias
                .SingleOrDefaultAsync(m => m.Id_Competencia == id);
            if (competencias == null)
            {
                return NotFound();
            }

            return View(competencias);
        }

        // POST: Competencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var competencias = await _context.Competencias.SingleOrDefaultAsync(m => m.Id_Competencia == id);
            _context.Competencias.Remove(competencias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenciasExists(string id)
        {
            return _context.Competencias.Any(e => e.Id_Competencia == id);
        }
    }
}
