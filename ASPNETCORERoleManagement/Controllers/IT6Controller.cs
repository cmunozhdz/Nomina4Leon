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
    public class IT6Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public IT6Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IT6
        public async Task<IActionResult> Index()
        {
            return View(await _context.IT6s.ToListAsync());
        }

        // GET: IT6/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT6 = await _context.IT6s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT6 == null)
            {
                return NotFound();
            }

            return View(iT6);
        }

        // GET: IT6/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IT6/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Stras,Colonia,Poblac,Cod_post,Estado,Munic,Land1,Telnr,PersonalId")] IT6 iT6)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iT6);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iT6);
        }

        // GET: IT6/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT6 = await _context.IT6s.SingleOrDefaultAsync(m => m.Id == id);
            if (iT6 == null)
            {
                return NotFound();
            }
            return View(iT6);
        }

        // POST: IT6/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Stras,Colonia,Poblac,Cod_post,Estado,Munic,Land1,Telnr,PersonalId")] IT6 iT6)
        {
            if (id != iT6.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iT6);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IT6Exists(iT6.Id))
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
            return View(iT6);
        }

        // GET: IT6/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT6 = await _context.IT6s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT6 == null)
            {
                return NotFound();
            }

            return View(iT6);
        }

        // POST: IT6/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iT6 = await _context.IT6s.SingleOrDefaultAsync(m => m.Id == id);
            _context.IT6s.Remove(iT6);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IT6Exists(int id)
        {
            return _context.IT6s.Any(e => e.Id == id);
        }
    }
}
