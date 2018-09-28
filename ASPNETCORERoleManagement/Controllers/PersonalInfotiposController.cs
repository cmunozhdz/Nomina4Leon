using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCORERoleManagement.Data;
using ASPNETCORERoleManagement.Models;

namespace ASPNETCORERoleManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PersonalInfotiposController : Controller
    {

        private readonly ApplicationDbContext _context;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
        public PersonalInfotiposController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.Message = "";
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string gpo = ViewBag.GpoCiaG;
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                List<Personal> divislist = new List<Personal>();
                divislist = (from divis2 in _context.Personals
                              select divis2).ToList();
                //agregando los items a la lista

                //asignar category list to viewbag
                ViewBag.ListofPersons = divislist;

                return View(await _context.Personals.ToListAsync());
            }
            else
            {
                List<Personal> divislist = new List<Personal>();
                divislist = (from divis2 in _context.Personals
                             select divis2).ToList();
                //agregando los items a la lista

                //asignar category list to viewbag
                ViewBag.ListofPersons = divislist;

                var x = HttpContext.Session.GetString(SessionGpoCia);
                return View(await _context.Personals.Where(c => c.Gbukrs == x).ToListAsync());
            }



          //  return View();
        }

        [HttpPost]
        public async Task<IActionResult> Busca1(int? id)
        {
            var personal = await _context.Personals
              .SingleOrDefaultAsync(m => m.Id == id);
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Edit", "Personals", new { id });
            //  return View();  en otros casos seria new {id = id }
        }



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
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:Personal_agregarVM");
                return RedirectToAction("Index", "GpoCiaGlobal");
                //return Redirect("GpoCiaGlobal/Index");
            }
            else
            {
                HttpContext.Session.SetString(SessionRegresa, "");
                return RedirectToAction("Create", "Personal_agregarVM");
            }
            //var items = new List<SelectListItem>();
            //items = DaBukrs(ViewBag.GpoCiaG);
           // ViewBag.DaBukrs = items.ToList();
           // return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecordCard(PersonalInfotipos viewModelx)
        {
            Personal personas = viewModelx.Personal;

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(viewModelx);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Personal.Id,Personal.Gbukrs,Personal.Bukrs,Personal.Pernr,Personal.Subty,Personal.Seqnr,Personal.BegDa,Personal.EndDa,Personal.Vorna,Personal.Nachn,Personal.Nach2,IdMassg,IT0.Estatus")] PersonalInfotipos personal)
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
            var x = id;

            return RedirectToAction("Edit","Personals", new { id = x });
            var personal = await _context.Personals.SingleOrDefaultAsync(m => m.Id == id);
            if (personal == null)
            {
                return NotFound();
            }
            return View(personal);
        }








        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,BegDa,EndDa,Seqnr,Aedtm,Uname,Vorna,Nachn,Nach2")] Personal personal)
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

        public JsonResult GetCountryList(string searchTerm)
        {
            var CountryList = _context.Region1.ToList();
            if (searchTerm != null)
            {
                CountryList = _context.Region1.Where(x => x.nombre.Contains(searchTerm)).ToList();
            }
            var modifiedData = CountryList.Select(x => new
            {
                id = x.id,
                text = x.nombre
            });
            //return Json(modifiedData,j)
            return Json(new SelectList(modifiedData, "id", "text"));

        }

        public JsonResult GetClasedeMedida(string idp)
        {
            List<ClasedeMedida> DivisionList = new List<ClasedeMedida>();
            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            DivisionList = (from divisiones in _context.ClasedeMedida
                            where divisiones.Bukrs == idp && divisiones.Gbukrs == x
                            select divisiones).ToList();
            //inserta datos
   
            DivisionList.Insert(0, new ClasedeMedida { Id = 0,  Massg_desc = "Select", Massn_desc = " " });
            var modifiedData = DivisionList.Select(xy => new
            {
                id = xy.Id,
                text = (xy.Massg_desc).PadRight(16,' ') + "|" + (xy.Massn_desc).PadLeft(16,' ')
            });
            return Json(new SelectList(modifiedData, "id", "text"));
        }

        public JsonResult GetEstatusOcupacion(string idp)
        {
            List<Estatus_stat2> DivisionList = new List<Estatus_stat2>();
            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            DivisionList = (from divisiones in _context.Estatus_Stat2
                            where divisiones.Bukrs == idp && divisiones.Gbukrs == x
                            select divisiones).ToList();
            //inserta datos

            DivisionList.Insert(0, new Estatus_stat2 { Estatus = 0, Desc = "Select" });
            var modifiedData = DivisionList.Select(xy => new
            {
                id = xy.Estatus,
                text = (xy.Desc)
            });
            return Json(new SelectList(modifiedData, "id", "text"));
        }

        public class Select2PagedResult
        {
            public int Total { get; set; }
            public List<Select2Result> Results { get; set; }
        }
        public class Select2Result
        {
            public string id { get; set; }
            public string text { get; set; }
        }


        private List<SelectListItem> DaBukrs(string gbukrsp)
        {

            // traer datos entityfram
            List<string> bukrslist = new List<string>();
            IEnumerable<string> bukrslist2 = new List<string>();
            var items = new List<SelectListItem>();
            //agregando los items a la lista

            // traer datos entityfram
            bukrslist = (from cat13 in _context.Cat1
                         where cat13.Gbukrs == gbukrsp
                         select cat13.Bukrs).ToList();
            bukrslist2 = bukrslist.Distinct();
            items.Add(new SelectListItem
            {
                Text = "Selecciona",
                Value = "Selecciona"
            });

            foreach (string lista1 in bukrslist2)
            {

                items.Add(new SelectListItem
                {
                    Text = lista1,
                    Value = lista1
                });
            }
            return (items.ToList());
            //var items = new List<SelectListItem>();
        }


        private List<SelectListItem> DaMassg(string gbukrsp)
        {

            // traer datos entityfram
            List<string> massglist = new List<string>();
            IEnumerable<string> massglist2 = new List<string>();
            var items = new List<SelectListItem>();
            //agregando los items a la lista

            // traer datos entityfram
            massglist = (from clasedeMedida in _context.ClasedeMedida
                         where clasedeMedida.Gbukrs == gbukrsp
                         select clasedeMedida.Bukrs).ToList();
            massglist2 = massglist.Distinct();
            items.Add(new SelectListItem
            {
                Text = "Selecciona",
                Value = "Selecciona"
            });

            foreach (string lista1 in massglist2)
            {

                items.Add(new SelectListItem
                {
                    Text = lista1,
                    Value = lista1
                });
            }
            return (items.ToList());
            //var items = new List<SelectListItem>();
        }





    }
}