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
    public class ObjetivosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string  SessionId= "ObjetivoId";

        public ObjetivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Objetivos
        public async Task<IActionResult> Index(string id)
        {
            if (id == null) {
                return NotFound();
            }
            ViewBag.TipoObjId = id;

            return View(await _context.Objetivo.Where(c => c.TipoObjId == id).ToListAsync());


            
        }

        // GET: Objetivos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetivo = await _context.Objetivo
                .SingleOrDefaultAsync(m => m.IdObjetivo == id);
            if (objetivo == null)
            {
                return NotFound();
            }

            return View(objetivo);
        }

        // GET: Objetivos/Create
        public IActionResult Create(string id)
        {
            if (id == null) {
                return NotFound();
            }
            //ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            
            TipoObj SelectItem= new GetTipoObjDb().GetItem(id, _context);
            if (SelectItem == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.TipoObjetivo = SelectItem.TipoObjId;
                ViewBag.DescObjetivo = SelectItem.TipoObjId + ':'+ SelectItem.Descripcion;
                HttpContext.Session.SetString(SessionId, id);
                return View();
            }
                
            
        }

        // POST: Objetivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObjetivo,Descipcion,Inicio,Fin,TipoObjId")] Objetivo objetivo)
        {
            //Valida que no haya duplicados.
            if (_context.Objetivo.Any(a => a.IdObjetivo  == objetivo.IdObjetivo ))

            {

                ModelState.AddModelError("IdObjetivo", "El registro ya existe");
                TipoObj SelectItem = new GetTipoObjDb().GetItem(objetivo.TipoObjId , _context);
                if (SelectItem == null)
                {
                    return NotFound();
                }
                else
                {
                    ViewBag.TipoObjetivo = SelectItem.TipoObjId;
                    ViewBag.DescObjetivo = SelectItem.Descripcion; 
                    return View();
                }

            }


            if (ModelState.IsValid)
            {
                _context.Add(objetivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objetivo);
        }

        // GET: Objetivos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetivo = await _context.Objetivo.SingleOrDefaultAsync(m => m.IdObjetivo == id);
            if (objetivo == null)
            {
                return NotFound();
            }
            return View(objetivo);
        }

        // POST: Objetivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdObjetivo,Descipcion,Inicio,Fin,TipoObjId")] Objetivo objetivo)
        {
            if (id != objetivo.IdObjetivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objetivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjetivoExists(objetivo.IdObjetivo))
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
            return View(objetivo);
        }

        // GET: Objetivos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetivo = await _context.Objetivo
                .SingleOrDefaultAsync(m => m.IdObjetivo == id);
            if (objetivo == null)
            {
                return NotFound();
            }

            return View(objetivo);
        }

        // POST: Objetivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var objetivo = await _context.Objetivo.SingleOrDefaultAsync(m => m.IdObjetivo == id);
            _context.Objetivo.Remove(objetivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjetivoExists(string id)
        {
            return _context.Objetivo.Any(e => e.IdObjetivo == id);
        }
    }
}
