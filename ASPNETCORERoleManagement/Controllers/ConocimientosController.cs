using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCORERoleManagement.Data;
using ASPNETCORERoleManagement.Models;

namespace ASPNETCORERoleManagement.Controllers
{
    public class ConocimientosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConocimientosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conocimientos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conocimientos.ToListAsync());
        }

        // GET: Conocimientos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conocimientos = await _context.Conocimientos
                .SingleOrDefaultAsync(m => m.Id_Conocimientos == id);
            if (conocimientos == null)
            {
                return NotFound();
            }

            return View(conocimientos);
        }

        // GET: Conocimientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conocimientos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Conocimientos,Conocimiento_Desc,bukrs,gbukrs")] Conocimientos conocimientos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conocimientos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conocimientos);
        }

        // GET: Conocimientos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conocimientos = await _context.Conocimientos.SingleOrDefaultAsync(m => m.Id_Conocimientos == id);
            if (conocimientos == null)
            {
                return NotFound();
            }
            return View(conocimientos);
        }

        // POST: Conocimientos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id_Conocimientos,Conocimiento_Desc,bukrs,gbukrs")] Conocimientos conocimientos)
        {
            if (id != conocimientos.Id_Conocimientos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conocimientos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConocimientosExists(conocimientos.Id_Conocimientos))
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
            return View(conocimientos);
        }

        // GET: Conocimientos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conocimientos = await _context.Conocimientos
                .SingleOrDefaultAsync(m => m.Id_Conocimientos == id);
            if (conocimientos == null)
            {
                return NotFound();
            }

            return View(conocimientos);
        }

        // POST: Conocimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var conocimientos = await _context.Conocimientos.SingleOrDefaultAsync(m => m.Id_Conocimientos == id);
            _context.Conocimientos.Remove(conocimientos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConocimientosExists(string id)
        {
            return _context.Conocimientos.Any(e => e.Id_Conocimientos == id);
        }
    }
}
