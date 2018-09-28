using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCORERoleManagement.Data;
using ASPNETCORERoleManagement.Models;
using ASPNETCORERoleManagement.Models.PersonalViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using ASPNETCORERoleManagement.Services;
using System.Security.Claims;

namespace ASPNETCORERoleManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IT0_1Controller : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IRepositorioBukrs _bukrs;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";

        public IT0_1Controller(ApplicationDbContext context, IRepositorioBukrs bukrs)
        {
            _context = context;
            _bukrs = bukrs;
        }

        // GET: IT0_1
        public async Task<IActionResult> Index()
        {
            return View(await _context.IT0s.ToListAsync());
        }

        // GET: IT0_1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT0 = await _context.IT0s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT0 == null)
            {
                return NotFound();
            }

            return View(iT0);
        }

        // GET: IT0_1/Create
        public IActionResult Create()
        {
            return View();
        }



        // POST: IT0_1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Massn,Massg,Estatus,PersonalId")] IT0 iT0)
        {
            if (ModelState.IsValid)
            {

                // cambiar el anterior
                var lastIt0 = await _context.IT0s.LastOrDefaultAsync(m => m.PersonalId == iT0.PersonalId);
                if (lastIt0 == null)
                {
                }
                else
                {
                    lastIt0.EndDa = iT0.BegDa.AddDays(-1);
                    _context.Update(lastIt0);
                   
                    await _context.SaveChangesAsync();
                }
                // agregar el nuevo
                _context.Add(iT0);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iT0);
        }

        // GET: IT0_1/Create
        public async Task<IActionResult> Crear(int? IdPer)
        {
            if (IdPer == null)
            {
                return NotFound();
            }
            IT0 it0p = new IT0();
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
            var lastIt0 = await _context.IT0s.LastOrDefaultAsync(m => m.PersonalId == IdPer);
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
        public async Task<IActionResult> Crear([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Massn,Massg,Estatus,PersonalId")] IT0 iT0)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iT0);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                var x = iT0.PersonalId;
               return RedirectToAction("Edit", "Personals", new { id = x });
            }
            var personal = await _context.Personals
        .SingleOrDefaultAsync(m => m.Id == iT0.PersonalId);
            ViewBag.GpoCiaG = iT0.Gbukrs;
            ViewBag.Nombre = personal.Cname;
            ViewBag.Bukrs = iT0.Bukrs;
            ViewBag.NoPer = iT0.Pernr;
            var items = new List<SelectListItem>();
            items = _bukrs.DaClasedeMedida(personal.Gbukrs, personal.Bukrs);
            ViewBag.ListaClases = items.ToList();
            var esta1 = new List<Estatus_stat2>();
            esta1 = _bukrs.GetEstatus1(personal.Bukrs, personal.Gbukrs);
            ViewBag.ListaEst = esta1.ToList();
            return View(iT0);
        }


        // GET: IT0_1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT0 = await _context.IT0s.SingleOrDefaultAsync(m => m.Id == id);
            if (iT0 == null)
            {
                return NotFound();
            }
            return View(iT0);
        }

        // POST: IT0_1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Massn,Massg,Estatus,PersonalId")] IT0 iT0)
        {
            if (id != iT0.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iT0);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IT0Exists(iT0.Id))
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
            return View(iT0);
        }

        // GET: IT0_1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT0 = await _context.IT0s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT0 == null)
            {
                return NotFound();
            }

            return View(iT0);
        }

        // POST: IT0_1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iT0 = await _context.IT0s.SingleOrDefaultAsync(m => m.Id == id);
            _context.IT0s.Remove(iT0);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IT0Exists(int id)
        {
            return _context.IT0s.Any(e => e.Id == id);
        }

        public JsonResult GetMassg1(string idp , string bukrs, string gbukrs)
        {

            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            //inserta datos

            var modifiedData = new List<SelectListItem>();
            modifiedData = _bukrs.DaMassg1(gbukrs,bukrs, idp);
            return Json(modifiedData);
        }








    }
}
