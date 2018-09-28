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
    public class IT369Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public IT369Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IT369
        public async Task<IActionResult> Index()
        {
            return View(await _context.IT369s.ToListAsync());
        }

        // GET: IT369/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT369 = await _context.IT369s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT369 == null)
            {
                return NotFound();
            }

            return View(iT369);
        }

        // GET: IT369/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IT369/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Rimss,Nimss,Ijred,PersonalId")] IT369 iT369)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iT369);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iT369);
        }

        // GET: IT369/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT369 = await _context.IT369s.SingleOrDefaultAsync(m => m.Id == id);
            if (iT369 == null)
            {
                return NotFound();
            }
            return View(iT369);
        }

        // POST: IT369/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Rimss,Nimss,Ijred,PersonalId")] IT369 iT369)
        {
            if (id != iT369.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iT369);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IT369Exists(iT369.Id))
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
            return View(iT369);
        }

        // GET: IT369/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT369 = await _context.IT369s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT369 == null)
            {
                return NotFound();
            }

            return View(iT369);
        }

        // POST: IT369/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iT369 = await _context.IT369s.SingleOrDefaultAsync(m => m.Id == id);
            _context.IT369s.Remove(iT369);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IT369Exists(int id)
        {
            return _context.IT369s.Any(e => e.Id == id);
        }
    }
}
