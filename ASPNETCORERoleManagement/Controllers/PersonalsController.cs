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
    public class PersonalsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PersonalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Personals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personals.ToListAsync());
        }

        // GET: Personals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals
                .SingleOrDefaultAsync(m => m.Id == id);
            if (personal == null)
            {
                return NotFound();
            }

            return View(personal);
        }

        // GET: Personals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Vorna,Nachn,Nach2,Cname")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personal);
        }

        // GET: Personals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
  
            if (id == null)
            {
                return NotFound();
            }
         //   ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            var personal = await _context.Personals.SingleOrDefaultAsync(m => m.Id == id);
            //var personal = await _context.Personals.Where(x => x.Id == id).Include(x => x.IT0s).ToList();
            if (personal == null)
            {
                return NotFound();
            }
            ViewBag.GpoCiaG = personal.Gbukrs;

            List<IT0> it0s = new List<IT0>();
            it0s = (from ito in _context.IT0s
                       where ito.PersonalId == personal.Id
                       select ito).ToList();


            personal.IT0s = it0s;
            var query_join4 = from a in _context.IT0s
                              join c in _context.ClasedeMedida
                              on new { a.Gbukrs,a.Bukrs,a.Massn, a.Massg } equals new { c.Gbukrs,c.Bukrs,c.Massn, c.Massg }
                              join l in _context.Estatus_Stat2
                              on new { a.Gbukrs, a.Bukrs,a.Estatus } equals new { l.Gbukrs, l.Bukrs, l.Estatus }
                              select new
                              {
                                  BegDa1 = a.BegDa,
                                  EndDa1 = a.EndDa,
                                  Estatus = l.Desc,
                                  Massn = c.Massn_desc,
                                  Massg = c.Massg_desc
                              };
            ViewBag.ListaIt0 = query_join4.ToList();
            List<IT1> itp1 = new List<IT1>();
            itp1 = (from ito in _context.IT1s
                    where ito.PersonalId == personal.Id
                    select ito).ToList();


            personal.IT1s = itp1;

            List<IT16> itp16 = new List<IT16>();

            itp16 = (from ito in _context.IT16s
                    where ito.PersonalId == personal.Id
                    select ito).ToList();


            personal.IT16s = itp16;

            List<IT21> itp21 = new List<IT21>();

            itp21 = (from ito in _context.IT21s
                     where ito.PersonalId == personal.Id
                     select ito).ToList();


            personal.IT21s = itp21;

            List<IT2_185_105> itp2 = new List<IT2_185_105>();

            itp2 = (from ito in _context.IT2_185_105s
                     where ito.PersonalId == personal.Id
                     select ito).ToList();


            personal.IT2_185_105s = itp2;


            List<IT369> itp369 = new List<IT369>();

            itp369 = (from ito in _context.IT369s
                     where ito.PersonalId == personal.Id
                     select ito).ToList();


            personal.IT369x = itp369;


            List<IT41> itp41 = new List<IT41>();

            itp41 = (from ito in _context.IT41s
                     where ito.PersonalId == personal.Id
                     select ito).ToList();


            personal.IT41s = itp41;


            List<IT6> itp6 = new List<IT6>();

            itp6 = (from ito in _context.IT6s
                     where ito.PersonalId == personal.Id
                     select ito).ToList();


            personal.IT6s = itp6;



            List<IT7> itp7 = new List<IT7>();

            itp7 = (from ito in _context.IT7s
                    where ito.PersonalId == personal.Id
                    select ito).ToList();


            personal.IT7s = itp7;



            List<IT8> itp8 = new List<IT8>();

            itp8 = (from ito in _context.IT8s
                    where ito.PersonalId == personal.Id
                    select ito).ToList();


            personal.IT8s = itp8;

            List<IT9> itp9 = new List<IT9>();

            itp9 = (from ito in _context.IT9s
                    where ito.PersonalId == personal.Id
                    select ito).ToList();


            personal.IT9s = itp9;







            return View(personal);
        }

        // POST: Personals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Vorna,Nachn,Nach2,Cname")] Personal personal)
        {
            if (id != personal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalExists(personal.Id))
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
            return View(personal);
        }

        // GET: Personals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals
                .SingleOrDefaultAsync(m => m.Id == id);
            if (personal == null)
            {
                return NotFound();
            }

            return View(personal);
        }

        // POST: Personals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personal = await _context.Personals.SingleOrDefaultAsync(m => m.Id == id);
            _context.Personals.Remove(personal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalExists(int id)
        {
            return _context.Personals.Any(e => e.Id == id);
        }
    }
}
