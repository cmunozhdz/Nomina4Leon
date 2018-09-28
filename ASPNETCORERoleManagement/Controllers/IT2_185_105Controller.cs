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
    public class IT2_185_105Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositorioBukrs _bukrs;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
        public IT2_185_105Controller(ApplicationDbContext context, IRepositorioBukrs bukrs)
        {
            _context = context;
            _bukrs = bukrs;
        }

        // GET: IT2_185_105
        public async Task<IActionResult> Index()
        {
            return View(await _context.IT2_185_105s.ToListAsync());
        }

        // GET: IT2_185_105/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT2_185_105 = await _context.IT2_185_105s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT2_185_105 == null)
            {
                return NotFound();
            }

            return View(iT2_185_105);
        }

        // GET: IT2_185_105/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: IT0_1/Create
        public async Task<IActionResult> Crear(int? IdPer)
        {
            if (IdPer == null)
            {
                return NotFound();
            }
            IT2_185_105 it0p = new IT2_185_105();
            var personal = await _context.Personals
             .SingleOrDefaultAsync(m => m.Id == IdPer);
            ViewBag.GpoCiaG = personal.Gbukrs;
            ViewBag.Nombre = personal.Cname;
            ViewBag.Bukrs = personal.Bukrs;
            ViewBag.ListofRegion1 = _bukrs.GetRegion1();

            ViewBag.NoPer = personal.Pernr;
            ViewBag.ListofClavedeSexo = _bukrs.GetClavedeSexo();
            var items = new List<SelectListItem>();
            items = _bukrs.DaClasedeMedida(personal.Gbukrs, personal.Bukrs);
            ViewBag.ListaClases = items.ToList();
            var esta1 = new List<Estatus_stat2>();
            esta1 = _bukrs.GetEstatus1(personal.Bukrs, personal.Gbukrs);
            ViewBag.ListaEst = esta1.ToList();
            var lastIt0 = await _context.IT2_185_105s.LastOrDefaultAsync(m => m.PersonalId == IdPer);
            if (lastIt0 == null)
            {

                it0p.BegDa = DateTime.Now;

            }
            else
            {
                it0p.BegDa = lastIt0.BegDa.AddDays(1);
                it0p.Rfc = lastIt0.Rfc;
                it0p.Afore = lastIt0.Afore;
                it0p.Cartilla = lastIt0.Cartilla;
                it0p.Curp = lastIt0.Curp;
                it0p.Fm2 = lastIt0.Fm2;
                it0p.Fm3 = lastIt0.Fm3;
                it0p.GbDat = lastIt0.GbDat;
                it0p.Gbdep = lastIt0.Gbdep;
                it0p.Gblnd = lastIt0.Gblnd;
                it0p.Gbort = lastIt0.Gbort;
                it0p.Gesch = lastIt0.Gesch;
                it0p.Ine = lastIt0.Ine;
                it0p.Issste = lastIt0.Issste;
                it0p.Licencia = lastIt0.Licencia;
                it0p.Natio = lastIt0.Natio;
                it0p.Pasaporte = lastIt0.Pasaporte;
                it0p.Subty = lastIt0.Subty;
                it0p.Titl2 = lastIt0.Titl2;
                it0p.Title = lastIt0.Title;
                it0p.Usrid1 = lastIt0.Usrid1;
                it0p.Usrid2 = lastIt0.Usrid2;
                it0p.Usrid3 = lastIt0.Usrid3;
                it0p.Usrid4 = lastIt0.Usrid4;
                it0p.Usrty1 = lastIt0.Usrty1;
                it0p.Usrty2 = lastIt0.Usrty2;
                it0p.Usrty3 = lastIt0.Usrty3;
                it0p.Usrty4 = lastIt0.Usrty4;


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

            return View(it0p);
        }



        // POST: IT0_1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Title,Titl2,Curp,Gesch,GbDat,Gblnd,Gbdep,Gbort,Natio,Usrty1,Usrid1,Usrty2,Usrid2,Usrty3,Usrid3,Usrty4,Usrid4,Ine,Rfc,Licencia,Cartilla,Pasaporte,Fm2,Fm3,Issste,Afore,PersonalId")] IT2_185_105 iT2_185_105)
        {
            if (ModelState.IsValid)
            {
                var lastIt0 = await _context.IT2_185_105s.LastOrDefaultAsync(m => m.PersonalId == iT2_185_105.PersonalId);
                if (lastIt0 == null)
                { }
                else
                {
                    lastIt0.EndDa = iT2_185_105.BegDa.AddDays(-1);
                    _context.Update(lastIt0);
                    await _context.SaveChangesAsync();
                }

                _context.Add(iT2_185_105);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                var x = iT2_185_105.PersonalId;
                return RedirectToAction("Edit", "Personals", new { id = x });
            }
            var personal = await _context.Personals
        .SingleOrDefaultAsync(m => m.Id == iT2_185_105.PersonalId);
            ViewBag.GpoCiaG = iT2_185_105.Gbukrs;
            ViewBag.Nombre = personal.Cname;
            ViewBag.Bukrs = iT2_185_105.Bukrs;
            ViewBag.NoPer = iT2_185_105.Pernr;
            ViewBag.ListofRegion1 = _bukrs.GetRegion1();

            ViewBag.ListofClavedeSexo = _bukrs.GetClavedeSexo();
            var items = new List<SelectListItem>();
            items = _bukrs.DaClasedeMedida(personal.Gbukrs, personal.Bukrs);
            ViewBag.ListaClases = items.ToList();
            var esta1 = new List<Estatus_stat2>();
            esta1 = _bukrs.GetEstatus1(personal.Bukrs, personal.Gbukrs);
            ViewBag.ListaEst = esta1.ToList();
            return View(iT2_185_105);
        }

        // POST: IT2_185_105/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Title,Titl2,Curp,Gesch,GbDat,Gblnd,Gbdep,Gbort,Natio,Usrty1,Usrid1,Usrty2,Usrid2,Usrty3,Usrid3,Usrty4,Usrid4,Ine,Rfc,Licencia,Cartilla,Pasaporte,Fm2,Fm3,Issste,Afore,PersonalId")] IT2_185_105 iT2_185_105)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iT2_185_105);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iT2_185_105);
        }

        // GET: IT2_185_105/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT2_185_105 = await _context.IT2_185_105s.SingleOrDefaultAsync(m => m.Id == id);
            if (iT2_185_105 == null)
            {
                return NotFound();
            }
            return View(iT2_185_105);
        }

        // POST: IT2_185_105/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Title,Titl2,Curp,Gesch,GbDat,Gblnd,Gbdep,Gbort,Natio,Usrty1,Usrid1,Usrty2,Usrid2,Usrty3,Usrid3,Usrty4,Usrid4,Ine,Rfc,Licencia,Cartilla,Pasaporte,Fm2,Fm3,Issste,Afore,PersonalId")] IT2_185_105 iT2_185_105)
        {
            if (id != iT2_185_105.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iT2_185_105);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IT2_185_105Exists(iT2_185_105.Id))
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
            return View(iT2_185_105);
        }

        // GET: IT2_185_105/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT2_185_105 = await _context.IT2_185_105s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT2_185_105 == null)
            {
                return NotFound();
            }

            return View(iT2_185_105);
        }

        // POST: IT2_185_105/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iT2_185_105 = await _context.IT2_185_105s.SingleOrDefaultAsync(m => m.Id == id);
            _context.IT2_185_105s.Remove(iT2_185_105);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IT2_185_105Exists(int id)
        {
            return _context.IT2_185_105s.Any(e => e.Id == id);
        }
    }
}
