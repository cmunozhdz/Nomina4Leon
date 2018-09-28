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
using Microsoft.AspNetCore.Http;

namespace ASPNETCORERoleManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IT1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositorioBukrs _bukrs;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";

        public IT1Controller(ApplicationDbContext context, IRepositorioBukrs bukrs)
        {
            _context = context;
            _bukrs = bukrs;

        }

        // GET: IT1
        public async Task<IActionResult> Index()
        {
            return View(await _context.IT1s.ToListAsync());
        }

        // GET: IT1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT1 = await _context.IT1s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT1 == null)
            {
                return NotFound();
            }

            return View(iT1);
        }

        // GET: IT1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IT1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Divi,Tipo_pers,Area_pers,Subdivis,Nomina,Cent_cost,Orgeh,Plans,Stell,PersonalId")] IT1 iT1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iT1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iT1);
        }


        public async Task<IActionResult> Crear(int? IdPer)
        {
            if (IdPer == null)
            {
                return NotFound();
            }
            IT1 it0p = new IT1();
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
            var divis = new List<Divis>();
            divis = _bukrs.GetDivisions(personal.Bukrs,personal.Gbukrs );
            ViewBag.ListaDivis = divis.ToList();
            ViewBag.ListaNomina = _bukrs.GetNomina(personal.Bukrs, personal.Gbukrs).ToList();
            ViewBag.CentroCostos = _bukrs.GetCentrodeCostos(personal.Bukrs,personal.Gbukrs).ToList();
            var tipoper = new List<SelectListItem>();
            tipoper = _bukrs.GetTipoPersonal(personal.Bukrs, personal.Gbukrs);
            ViewBag.TipoPers = tipoper.ToList();
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
        public async Task<IActionResult> Crear([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Divi,Subdivis,Tipo_pers,Area_pers,Nomina,Cent_cost,Orgeh,Plans,Stell,PersonalId")] IT1 iT1)
        {
            if (ModelState.IsValid)
            {
                // cambiar el anterior
                var lastIt0 = await _context.IT1s.LastOrDefaultAsync(m => m.PersonalId == iT1.PersonalId);
                if (lastIt0 == null)
                {                }
                else
                {
                    lastIt0.EndDa = iT1.BegDa.AddDays(-1);
                    _context.Update(lastIt0);
                    await _context.SaveChangesAsync();
                }
                // agregar el nuevo
                _context.Add(iT1);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                var x = iT1.PersonalId;
                return RedirectToAction("Edit", "Personals", new { id = x });
            }
            var personal = await _context.Personals
        .SingleOrDefaultAsync(m => m.Id == iT1.PersonalId);
            ViewBag.GpoCiaG = iT1.Gbukrs;
            ViewBag.Nombre = personal.Cname;
            ViewBag.Bukrs = iT1.Bukrs;
            ViewBag.NoPer = iT1.Pernr;
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
            return View(iT1);
        }


        // GET: IT1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT1 = await _context.IT1s.SingleOrDefaultAsync(m => m.Id == id);
            if (iT1 == null)
            {
                return NotFound();
            }
            return View(iT1);
        }

        // POST: IT1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Divi,Tipo_pers,Area_pers,Subdivis,Nomina,Cent_cost,Orgeh,Plans,Stell,PersonalId")] IT1 iT1)
        {
            if (id != iT1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iT1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IT1Exists(iT1.Id))
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
            return View(iT1);
        }

        // GET: IT1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iT1 = await _context.IT1s
                .SingleOrDefaultAsync(m => m.Id == id);
            if (iT1 == null)
            {
                return NotFound();
            }

            return View(iT1);
        }

        // POST: IT1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iT1 = await _context.IT1s.SingleOrDefaultAsync(m => m.Id == id);
            _context.IT1s.Remove(iT1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IT1Exists(int id)
        {
            return _context.IT1s.Any(e => e.Id == id);
        }

        public JsonResult GetSubdivis(string bukrs, string divis,string gbukrs)
        {

            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = gbukrs;
            //inserta datos

            var modifiedData = new List<SelectListItem>();
            modifiedData = _bukrs.GetSubdivis(bukrs, x, divis);
            return Json(modifiedData);
        }

        public JsonResult GetAreaPer(string bukrs, int tipoper, string gbukrs)
        {

            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = gbukrs;
            //inserta datos

            var modifiedData = new List<SelectListItem>();
            modifiedData = _bukrs.GetAreaPer(bukrs, x, tipoper);
            return Json(modifiedData);
        }



    }
}
