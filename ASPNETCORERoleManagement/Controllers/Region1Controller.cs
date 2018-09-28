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
    public class Region1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Region1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Region1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Region1.ToListAsync());
        }

        // GET: Region1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region1 = await _context.Region1
                .SingleOrDefaultAsync(m => m.id == id);
            if (region1 == null)
            {
                return NotFound();
            }

            return View(region1);
        }

        // GET: Region1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Region1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,rg,nombre")] Region1 region1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(region1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(region1);
        }

        // GET: Region1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region1 = await _context.Region1.SingleOrDefaultAsync(m => m.id == id);
            if (region1 == null)
            {
                return NotFound();
            }
            return View(region1);
        }

        // POST: Region1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,rg,nombre")] Region1 region1)
        {
            if (id != region1.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(region1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Region1Exists(region1.id))
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
            return View(region1);
        }

        // GET: Region1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region1 = await _context.Region1
                .SingleOrDefaultAsync(m => m.id == id);
            if (region1 == null)
            {
                return NotFound();
            }

            return View(region1);
        }

        // POST: Region1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var region1 = await _context.Region1.SingleOrDefaultAsync(m => m.id == id);
            _context.Region1.Remove(region1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Region1Exists(int id)
        {
            return _context.Region1.Any(e => e.id == id);
        }
    }
}
