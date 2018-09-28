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
    public class IT7Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public IT7Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IT7
        public async Task<IActionResult> Index()
        {
            return View(await _context.IT7s.ToListAsync());
        }

        // GET: IT7/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT7 = await _context.IT7s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT7 == null)
            {
                return NotFound();
            }

            return View(iT7);
        }

        // GET: IT7/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IT7/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Hrs_Trab,Hr_Entrada,Hr_Salida,Hr_Pausa1,Hr_Pausa2,Dia_1,Dia_2,Dia_3,Dia_4,Dia_5,Dia_6,Dia_7,PersonalId")] IT7 iT7)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iT7);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iT7);
        }

        // GET: IT7/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT7 = await _context.IT7s.SingleOrDefaultAsync(m => m.Id == id);
            if (iT7 == null)
            {
                return NotFound();
            }
            return View(iT7);
        }

        // POST: IT7/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Hrs_Trab,Hr_Entrada,Hr_Salida,Hr_Pausa1,Hr_Pausa2,Dia_1,Dia_2,Dia_3,Dia_4,Dia_5,Dia_6,Dia_7,PersonalId")] IT7 iT7)
        {
            if (id != iT7.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iT7);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IT7Exists(iT7.Id))
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
            return View(iT7);
        }

        // GET: IT7/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT7 = await _context.IT7s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT7 == null)
            {
                return NotFound();
            }

            return View(iT7);
        }

        // POST: IT7/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iT7 = await _context.IT7s.SingleOrDefaultAsync(m => m.Id == id);
            _context.IT7s.Remove(iT7);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IT7Exists(int id)
        {
            return _context.IT7s.Any(e => e.Id == id);
        }
    }
}
