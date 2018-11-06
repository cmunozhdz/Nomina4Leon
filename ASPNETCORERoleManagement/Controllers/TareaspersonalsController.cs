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
    public class TareaspersonalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TareaspersonalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tareaspersonals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tareaspersonal.Include(t => t.Tareas);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tareaspersonals/Details/5
        public async Task<IActionResult> Details(string id, string PERNR)
        {
            if ((id == null) || (PERNR==null))
            {
                return NotFound();
            }

            var tareaspersonal = await _context.Tareaspersonal
                .Include(t => t.Tareas)
                .SingleOrDefaultAsync(m => m.TareaId == id && m.PERNR==PERNR );
            if (tareaspersonal == null)
            {
                return NotFound();
            }

            return View(tareaspersonal);
        }

        // GET: Tareaspersonals/Create
        public IActionResult Create()
        {
            ViewData["TareaId"] = new SelectList(_context.Tareas, "TareaId", "TareaId");
            return View();
        }

        // POST: Tareaspersonals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TareaId,PERNR,Observaciones,FRegistro,PorcAvance")] Tareaspersonal tareaspersonal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tareaspersonal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TareaId"] = new SelectList(_context.Tareas, "TareaId", "TareaId", tareaspersonal.TareaId);
            return View(tareaspersonal);
        }

        // GET: Tareaspersonals/Edit/5
        
        public async Task<IActionResult> Edit(string id,string PERNR)
        {
            if ((id == null) || (PERNR ==null))
            {
                return NotFound();
            }

            var tareaspersonal = await _context.Tareaspersonal.SingleOrDefaultAsync(m => m.TareaId == id && m.PERNR == PERNR );
            if (tareaspersonal == null)
            {
                return NotFound();
            }
            ViewData["TareaId"] = new SelectList(_context.Tareas, "TareaId", "TareaId", tareaspersonal.TareaId);
            return View(tareaspersonal);
        }

        // POST: Tareaspersonals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,string PERNR, [Bind("TareaId,PERNR,Observaciones,FRegistro,PorcAvance")] Tareaspersonal tareaspersonal)
        {
            if ((id != tareaspersonal.TareaId) && (PERNR != tareaspersonal.PERNR ))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tareaspersonal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TareaspersonalExists(tareaspersonal.TareaId,tareaspersonal.PERNR ))
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
            ViewData["TareaId"] = new SelectList(_context.Tareas, "TareaId", "TareaId", tareaspersonal.TareaId);
            return View(tareaspersonal);
        }

        // GET: Tareaspersonals/Delete/5
        public async Task<IActionResult> Delete(string id, string PERNR)
        {
            if ((id == null) || (PERNR ==null))
            {
                return NotFound();
            }

            var tareaspersonal = await _context.Tareaspersonal
                .Include(t => t.Tareas)
                .SingleOrDefaultAsync(m => m.TareaId == id && m.PERNR ==PERNR );
            if (tareaspersonal == null)
            {
                return NotFound();
            }

            return View(tareaspersonal);
        }

        // POST: Tareaspersonals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id,string PERNR)
        {
            var tareaspersonal = await _context.Tareaspersonal.SingleOrDefaultAsync(m => m.TareaId == id && m.TareaId == PERNR );
            _context.Tareaspersonal.Remove(tareaspersonal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TareaspersonalExists(string id, string PERNR)
        {
            return _context.Tareaspersonal.Any(e => e.TareaId == id);
        }
    }
}
