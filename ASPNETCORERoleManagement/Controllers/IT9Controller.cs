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
    public class IT9Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public IT9Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IT9
        public async Task<IActionResult> Index()
        {
            return View(await _context.IT9s.ToListAsync());
        }

        // GET: IT9/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT9 = await _context.IT9s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT9 == null)
            {
                return NotFound();
            }

            return View(iT9);
        }

        // GET: IT9/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IT9/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Banco,Tipo_pago,Pais,Cuenta,Plaza_cta,Estado,Clabe_banco,PersonalId")] IT9 iT9)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iT9);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iT9);
        }

        // GET: IT9/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT9 = await _context.IT9s.SingleOrDefaultAsync(m => m.Id == id);
            if (iT9 == null)
            {
                return NotFound();
            }
            return View(iT9);
        }

        // POST: IT9/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Banco,Tipo_pago,Pais,Cuenta,Plaza_cta,Estado,Clabe_banco,PersonalId")] IT9 iT9)
        {
            if (id != iT9.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iT9);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IT9Exists(iT9.Id))
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
            return View(iT9);
        }

        // GET: IT9/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT9 = await _context.IT9s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT9 == null)
            {
                return NotFound();
            }

            return View(iT9);
        }

        // POST: IT9/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iT9 = await _context.IT9s.SingleOrDefaultAsync(m => m.Id == id);
            _context.IT9s.Remove(iT9);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IT9Exists(int id)
        {
            return _context.IT9s.Any(e => e.Id == id);
        }
    }
}
