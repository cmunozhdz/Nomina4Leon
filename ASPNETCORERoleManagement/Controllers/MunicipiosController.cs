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

    public class MunicipiosController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public MunicipiosController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        // GET: Municipios
        public async Task<IActionResult> Index(string municGenre ,string searchString)
        {

            //Use LINQ TO GET list of regiones

            IQueryable<string> genreQuery = from m in _context.Municipios
                                            orderby m.region
                                            select m.region;


            var munics = from m in _context.Municipios
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                munics = munics.Where(s => s.descripcion.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(municGenre ))
            {
                munics = munics.Where(x => x.region == municGenre);
            }
            var municsGenreVM = new MunicGenreViewModel();
            municsGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            municsGenreVM.municipios = await munics.ToListAsync();

            return View(municsGenreVM);
            //return View(await munics.ToListAsync());

            //return View(await _context.Municipios.ToListAsync());
        }

        // GET: Municipios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipios
                .SingleOrDefaultAsync(m => m.id == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // GET: Municipios/Create
        public IActionResult Create()
        {
            List<Region1> region1list = new List<Region1>();
            // traer datos entityfram
            region1list = (from region1 in _context.Region1
                           select region1).ToList();
            //agregando los items a la lista
            region1list.Insert(0, new Region1 { rg = "0", nombre = "Select" });
            //asignar category list to viewbag
            ViewBag.ListofCategory = region1list;

            return View();
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,mpio,descripcion,region")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(municipio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(municipio);
        }

        // GET: Municipios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipios.SingleOrDefaultAsync(m => m.id == id);
            if (municipio == null)
            {
                return NotFound();
            }

            List<Region1> region1list = new List<Region1>();
            // traer datos entityfram
            region1list = (from region1 in _context.Region1
                           select region1).ToList();
            //agregando los items a la lista
            // region1list.Insert(0, new Region1 { rg = cat1.Estado , nombre = cat1.Munic  });
            //asignar category list to viewbag
            ViewBag.ListofCategory = region1list;

            return View(municipio);
        }

        // POST: Municipios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,mpio,descripcion,region")] Municipio municipio)
        {
            if (id != municipio.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipioExists(municipio.id))
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
            return View(municipio);
        }

        // GET: Municipios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipios
                .SingleOrDefaultAsync(m => m.id == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var municipio = await _context.Municipios.SingleOrDefaultAsync(m => m.id == id);
            _context.Municipios.Remove(municipio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipioExists(int id)
        {
            return _context.Municipios.Any(e => e.id == id);
        }
    }
}
