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
    [Authorize(Roles = "Admin")]
    public class IT8Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public IT8Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IT8
        public async Task<IActionResult> Index()
        {
            return View(await _context.IT8s.ToListAsync());
        }

        // GET: IT8/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT8 = await _context.IT8s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT8 == null)
            {
                return NotFound();
            }

            return View(iT8);
        }

        // GET: IT8/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IT8/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Sueldo_dia,Sueldo_mens,Sdo_hora,PersonalId")] IT8 iT8)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iT8);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iT8);
        }

        // GET: IT8/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT8 = await _context.IT8s.SingleOrDefaultAsync(m => m.Id == id);
            if (iT8 == null)
            {
                return NotFound();
            }
            return View(iT8);
        }

        // POST: IT8/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Sueldo_dia,Sueldo_mens,Sdo_hora,PersonalId")] IT8 iT8)
        {
            if (id != iT8.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iT8);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IT8Exists(iT8.Id))
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
            return View(iT8);
        }

        // GET: IT8/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT8 = await _context.IT8s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT8 == null)
            {
                return NotFound();
            }

            return View(iT8);
        }

        // POST: IT8/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iT8 = await _context.IT8s.SingleOrDefaultAsync(m => m.Id == id);
            _context.IT8s.Remove(iT8);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IT8Exists(int id)
        {
            return _context.IT8s.Any(e => e.Id == id);
        }
    }
}
