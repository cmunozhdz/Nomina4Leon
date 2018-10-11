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
    public class TipoObjsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoObjsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoObjs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoObj.ToListAsync());
        }

        // GET: TipoObjs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoObj = await _context.TipoObj
                .SingleOrDefaultAsync(m => m.Id_TipoObj == id);
            if (tipoObj == null)
            {
                return NotFound();
            }

            return View(tipoObj);
        }

        // GET: TipoObjs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoObjs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_TipoObj,TipoObjetivo_Desc,bukrs,gbukrs")] TipoObj tipoObj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoObj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoObj);
        }

        // GET: TipoObjs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoObj = await _context.TipoObj.SingleOrDefaultAsync(m => m.Id_TipoObj == id);
            if (tipoObj == null)
            {
                return NotFound();
            }
            return View(tipoObj);
        }

        // POST: TipoObjs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id_TipoObj,TipoObjetivo_Desc,bukrs,gbukrs")] TipoObj tipoObj)
        {
            if (id != tipoObj.Id_TipoObj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoObj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoObjExists(tipoObj.Id_TipoObj))
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
            return View(tipoObj);
        }

        // GET: TipoObjs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoObj = await _context.TipoObj
                .SingleOrDefaultAsync(m => m.Id_TipoObj == id);
            if (tipoObj == null)
            {
                return NotFound();
            }

            return View(tipoObj);
        }

        // POST: TipoObjs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tipoObj = await _context.TipoObj.SingleOrDefaultAsync(m => m.Id_TipoObj == id);
            _context.TipoObj.Remove(tipoObj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoObjExists(string id)
        {
            return _context.TipoObj.Any(e => e.Id_TipoObj == id);
        }
    }
}
