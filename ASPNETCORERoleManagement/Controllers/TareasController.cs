using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCORERoleManagement.Data;
using ASPNETCORERoleManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCORERoleManagement.Controllers
{
    [Authorize(Roles = "Admin")] //Fija los permisos.
    public class TareasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TareasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tareas
        public async Task<IActionResult> Index(string ObjetivoId)
        {
            if (ObjetivoId==null )
            {
              
                var applicationDbContext = _context.Tareas.Include(t => t.Objetivo).ThenInclude(tp => tp.TipoObj);
                
                return View(await applicationDbContext.ToListAsync());
            }
            else
            
            {
                var applicationDbContext = _context.Tareas.Include(t => t.Objetivo)
                    .ThenInclude(tp=>tp.TipoObj) 
                    .Where(c=>c.IdObjetivo==ObjetivoId)  ;
                return View(await applicationDbContext.ToListAsync());
            }


        }

        // GET: Tareas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareas = await _context.Tareas
                .Include(t => t.Objetivo)
                .ThenInclude (tp=>tp.TipoObj)
                .SingleOrDefaultAsync(m => m.TareaId == id);
            if (tareas == null)
            {
                return NotFound();
            }

            return View(tareas);
        }

        // GET: Tareas/Create
        public IActionResult Create()
        {
            ViewBag.TareasFechaRegistro = DateTime.Now;
          
            ViewData["IdObjetivo"] = ListObjetivos("");

            return View(new Models.Tareas());
            
        }

        // POST: Tareas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TareaId,IdObjetivo,TareasDesc,TareasFechaRegistro,TareasFechaFinDeseado,TareasFechaFinReal")] Tareas tareas)
        {
            if (ModelState.IsValid) {
                //Valida que no haya datos duplicados.
                if (TareasExists(tareas.TareaId )) {
                    ModelState.AddModelError("ErrorEnDB", "El registro ya existe.");
                    ViewBag.TareasFechaRegistro = DateTime.Now;

                }
            }

            if (ModelState.IsValid)
            {

                _context.Add(tareas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else {
                ViewBag.Errors = "";

                //foreach (var modelError in ModelState)
                //{
                //    string propertyName = modelError.Key;
                //    if (modelError.Value.Errors.Count > 0)
                //    {
                //        ViewBag.Errors = ViewBag.Errors + "**** " + propertyName + "|" + modelError.Value.Errors.Count;

                //    }
                //}
            }
            
            ViewData["IdObjetivo"] = ListObjetivos(tareas.IdObjetivo);
            return View(tareas);
        }

        // GET: Tareas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareas = await _context.Tareas.Include(t=>t.Objetivo)
                .ThenInclude(tp=>tp.TipoObj)
                .SingleOrDefaultAsync(m => m.TareaId == id);

            //var applicationDbContext = _context.Tareas.Include(t => t.Objetivo).ThenInclude(tp => tp.TipoObj);
            if (tareas == null)
            {
                return NotFound();
            }
            ViewData["IdObjetivo"] = ListObjetivos(tareas.IdObjetivo);
            return View(tareas);
        }

        // POST: Tareas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TareaId,IdObjetivo,TareasDesc,TareasFechaRegistro,TareasFechaFinDeseado,TareasFechaFinReal")] Tareas tareas)
        {
            if (id != tareas.TareaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tareas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TareasExists(tareas.TareaId))
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
            ViewData["IdObjetivo"] = ListObjetivos(tareas.IdObjetivo);
            return View(tareas);
        }

        // GET: Tareas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareas = await _context.Tareas
                .Include(t => t.Objetivo)
                .ThenInclude(tp=>tp.TipoObj) 
                .SingleOrDefaultAsync(m => m.TareaId == id);
            if (tareas == null)
            {
                return NotFound();
            }

            return View(tareas);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tareas = await _context.Tareas.SingleOrDefaultAsync(m => m.TareaId == id);
            _context.Tareas.Remove(tareas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TareasExists(string id)
        {
            return _context.Tareas.Any(e => e.TareaId == id);
        }
        private SelectList ListObjetivos(string _Selectitem ) {
            //Devuelve la lista de objetivos
            if (_Selectitem ==null)
            {
                return new SelectList(_context.Objetivo, "IdObjetivo", "Descripcion");
            }
            else
            {
                return new SelectList(_context.Objetivo, "IdObjetivo", "Descripcion", _Selectitem);
            }
            

        }

      
    }
}
