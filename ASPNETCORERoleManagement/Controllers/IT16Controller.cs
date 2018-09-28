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
using ASPNETCORERoleManagement.Services;
using System.Security.Claims;

namespace ASPNETCORERoleManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IT16Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositorioBukrs _bukrs;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
        public IT16Controller(ApplicationDbContext context, IRepositorioBukrs bukrs)
        {
            _context = context;
            _bukrs = bukrs;
        }

        // GET: IT16
        public async Task<IActionResult> Index()
        {
            return View(await _context.IT16s.ToListAsync());
        }

        // GET: IT16/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT16 = await _context.IT16s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT16 == null)
            {
                return NotFound();
            }

            return View(iT16);
        }

        // GET: IT16/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IT16/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Cttyp,Prbzt,Prbeh,PersonalId")] IT16 iT16)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iT16);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iT16);
        }


        // GET: IT0_1/Create
        public async Task<IActionResult> Crear(int? IdPer)
        {
            if (IdPer == null)
            {
                return NotFound();
            }
            IT16 it0p = new IT16();
            var personal = await _context.Personals
             .SingleOrDefaultAsync(m => m.Id == IdPer);
            ViewBag.GpoCiaG = personal.Gbukrs;
            ViewBag.Nombre = personal.Cname;
            ViewBag.Bukrs = personal.Bukrs;
            ViewBag.NoPer = personal.Pernr;
            var items = new List<SelectListItem>();
            items = _bukrs.DaClasedeMedida(personal.Gbukrs, personal.Bukrs);
            ViewBag.ListaClases = items.ToList();
            var esta1 = new List<Estatus_stat2>();
            esta1 = _bukrs.GetEstatus1(personal.Bukrs, personal.Gbukrs);
            ViewBag.ListaEst = esta1.ToList();
            var lastIt16 = await _context.IT16s.LastOrDefaultAsync(m => m.PersonalId == IdPer);
            if (lastIt16 == null)
            {

                it0p.BegDa = DateTime.Now;

            }
            else
            {
                it0p.BegDa = lastIt16.BegDa.AddDays(1);

            }
            it0p.Gbukrs = personal.Gbukrs;
            it0p.Bukrs = personal.Bukrs;
            string dateInput = "Jan 1, 9999";
            DateTime parsedDate = DateTime.Parse(dateInput);
            it0p.EndDa = parsedDate;
            var userNa = User.FindFirstValue(ClaimTypes.Name);
            it0p.Uname = userNa;
            it0p.Pernr = personal.Pernr;
            it0p.Aedtm = DateTime.Now;
            it0p.PersonalId = personal.Id;
            ViewBag.ListofClasedeContrato = _bukrs.GetClasedeContrato();
            ViewBag.ListofPerPru = _bukrs.GetPeriodoPrueba();

            return View(it0p);
        }



        // POST: IT0_1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Cttyp,Prbzt,Prbeh,PersonalId")] IT16 iT16)
        {
            if (ModelState.IsValid)
            {
                // cambiar el anterior
                var lastIt16 = await _context.IT16s.LastOrDefaultAsync(m => m.PersonalId == iT16.PersonalId);
                if (lastIt16 == null)
                {
                }
                else
                {
                    lastIt16.EndDa = iT16.BegDa.AddDays(-1);
                    _context.Update(lastIt16);
                    await _context.SaveChangesAsync();
                }
                // agregar el nuevo
                _context.Add(iT16);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                var x = iT16.PersonalId;
                return RedirectToAction("Edit", "Personals", new { id = x });
            }
            var personal = await _context.Personals
        .SingleOrDefaultAsync(m => m.Id == iT16.PersonalId);
            ViewBag.GpoCiaG = iT16.Gbukrs;
            ViewBag.Nombre = personal.Cname;
            ViewBag.Bukrs = iT16.Bukrs;
            ViewBag.NoPer = iT16.Pernr;
            var items = new List<SelectListItem>();
            items = _bukrs.DaClasedeMedida(personal.Gbukrs, personal.Bukrs);
            ViewBag.ListaClases = items.ToList();
            var esta1 = new List<Estatus_stat2>();
            esta1 = _bukrs.GetEstatus1(personal.Bukrs, personal.Gbukrs);
            ViewBag.ListaEst = esta1.ToList();
            ViewBag.ListofClasedeContrato = _bukrs.GetClasedeContrato();
            ViewBag.ListofPerPru = _bukrs.GetPeriodoPrueba();

            return View(iT16);
        }







        // GET: IT16/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT16 = await _context.IT16s.SingleOrDefaultAsync(m => m.Id == id);
            if (iT16 == null)
            {
                return NotFound();
            }
            return View(iT16);
        }

        // POST: IT16/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Cttyp,Prbzt,Prbeh,PersonalId")] IT16 iT16)
        {
            if (id != iT16.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iT16);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IT16Exists(iT16.Id))
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
            return View(iT16);
        }

        // GET: IT16/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT16 = await _context.IT16s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT16 == null)
            {
                return NotFound();
            }

            return View(iT16);
        }

        // POST: IT16/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iT16 = await _context.IT16s.SingleOrDefaultAsync(m => m.Id == id);
            _context.IT16s.Remove(iT16);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IT16Exists(int id)
        {
            return _context.IT16s.Any(e => e.Id == id);
        }
    }
}
