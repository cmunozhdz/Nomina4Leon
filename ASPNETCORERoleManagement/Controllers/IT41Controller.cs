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
    public class IT41Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositorioBukrs _bukrs;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
       
        public IT41Controller(ApplicationDbContext context, IRepositorioBukrs bukrs)
        {
            _context = context;
            _bukrs = bukrs;
        }

        // GET: IT41
        public async Task<IActionResult> Index()
        {
            return View(await _context.IT41s.ToListAsync());
        }

        // GET: IT41/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT41 = await _context.IT41s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT41 == null)
            {
                return NotFound();
            }

            return View(iT41);
        }

        // GET: IT41/Create
        public IActionResult Create()
        {
        
            return View();
        }

        // POST: IT41/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Dar01,Dat01,PersonalId")] IT41 iT41)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iT41);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iT41);
        }


        public async Task<IActionResult> Crear(int? IdPer)
        {
            if (IdPer == null)
            {
                return NotFound();
            }
            IT41 it0p = new IT41();
            var personal = await _context.Personals
             .SingleOrDefaultAsync(m => m.Id == IdPer);
            ViewBag.GpoCiaG = personal.Gbukrs;
            ViewBag.Nombre = personal.Cname;
            ViewBag.Bukrs = personal.Bukrs;
            ViewBag.NoPer = personal.Pernr;
            ViewBag.ListofPerPru = _bukrs.GetPeriodoPrueba();
            var items = new List<SelectListItem>();
            items = _bukrs.DaClasedeMedida(personal.Gbukrs, personal.Bukrs);
            ViewBag.ListaClases = items.ToList();
            var esta1 = new List<Estatus_stat2>();
            esta1 = _bukrs.GetEstatus1(personal.Bukrs, personal.Gbukrs);
            ViewBag.ListaEst = esta1.ToList();
            ViewBag.ClaseFechas = _bukrs.GetClasedeFecha();
            it0p.Dat01 = DateTime.Now;
            var lastIt0 = await _context.IT1s.LastOrDefaultAsync(m => m.PersonalId == IdPer);
            if (lastIt0 == null)
            {

                it0p.BegDa = DateTime.Now;

            }
            else
            {
                it0p.BegDa = lastIt0.BegDa.AddDays(1);

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
        public async Task<IActionResult> Crear([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Dar01,Dat01,PersonalId")] IT41 iT41)
        {
            if (ModelState.IsValid)
            {
                // cambiar el anterior
                var lastIt0 = await _context.IT41s.LastOrDefaultAsync(m => m.PersonalId == iT41.PersonalId && m.Dar01==iT41.Dar01);
                if (lastIt0 == null)
                { }
                else
                {
                    lastIt0.EndDa = iT41.BegDa.AddDays(-1);
                    _context.Update(lastIt0);
                    await _context.SaveChangesAsync();
                }
                // agregar el nuevo
                _context.Add(iT41);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                var x = iT41.PersonalId;
                return RedirectToAction("Edit", "Personals", new { id = x });
            }
            var personal = await _context.Personals
        .SingleOrDefaultAsync(m => m.Id == iT41.PersonalId);
            ViewBag.GpoCiaG = iT41.Gbukrs;
            ViewBag.Nombre = personal.Cname;
            ViewBag.Bukrs = iT41.Bukrs;
            ViewBag.NoPer = iT41.Pernr;
            ViewBag.ClaseFechas = _bukrs.GetClasedeFecha();
            var items = new List<SelectListItem>();
            items = _bukrs.DaClasedeMedida(personal.Gbukrs, personal.Bukrs);
            ViewBag.ListaClases = items.ToList();
            var esta1 = new List<Estatus_stat2>();
            esta1 = _bukrs.GetEstatus1(personal.Bukrs, personal.Gbukrs);
            ViewBag.ListaEst = esta1.ToList();
            var divis = new List<Divis>();
            divis = _bukrs.GetDivisions(personal.Bukrs, personal.Gbukrs);
            ViewBag.ListaDivis = divis.ToList();
            ViewBag.TipoPers = _bukrs.GetTipoPersonal(personal.Bukrs, personal.Gbukrs).ToList();
            ViewBag.ListaNomina = _bukrs.GetNomina(personal.Bukrs, personal.Gbukrs).ToList();
            ViewBag.CentroCostos = _bukrs.GetCentrodeCostos(personal.Bukrs, personal.Gbukrs).ToList();

            return View(iT41);
        }

        // GET: IT41/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT41 = await _context.IT41s.SingleOrDefaultAsync(m => m.Id == id);
            if (iT41 == null)
            {
                return NotFound();
            }
            return View(iT41);
        }

        // POST: IT41/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Dar01,Dat01,PersonalId")] IT41 iT41)
        {
            if (id != iT41.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iT41);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IT41Exists(iT41.Id))
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
            return View(iT41);
        }

        // GET: IT41/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT41 = await _context.IT41s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT41 == null)
            {
                return NotFound();
            }

            return View(iT41);
        }

        // POST: IT41/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iT41 = await _context.IT41s.SingleOrDefaultAsync(m => m.Id == id);
            _context.IT41s.Remove(iT41);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IT41Exists(int id)
        {
            return _context.IT41s.Any(e => e.Id == id);
        }
    }
}
