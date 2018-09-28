using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCORERoleManagement.Data;
using ASPNETCORERoleManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCORERoleManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Cat1Controller : Controller
    {
     
        private readonly ApplicationDbContext _context;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
        public Cat1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cat1
        public async Task<IActionResult> Index()
        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                return View(await _context.Cat1.ToListAsync());
            }
            else
            {
                var x = HttpContext.Session.GetString(SessionGpoCia);
                return View(await _context.Cat1.Where(c => c.Gbukrs == x).ToListAsync());
            }
           
        }

        // GET: Cat1/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var cat1 = await _context.Cat1
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cat1 == null)
            {
                return NotFound();
            }
  
            return View(cat1);
        }

        // GET: Cat1/Create
        public IActionResult Create2()
        {
            return View();
        }

        // <summary>
        // gpg
            public IActionResult Create()
        {
 
            //  si no selecciono gpocia lo direcciono a seleccionr
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
   
            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();

            List<Region1> region1list = new List<Region1>();
            // traer datos entityfram
            region1list = (from region1 in _context.Region1
                           select region1).ToList();

            //agregando los items a la lista
                ViewBag.ListofCategory = region1list;
      
    

            return View();
}


public JsonResult GetMunicipios(string  Region1)
{
    List<Municipio > Municipioslist = new List<Municipio >();
    //traer datos
    Municipioslist  = (from municipios in _context.Municipios 
                       where municipios.region  == Region1 
                       select municipios).ToList();
    //inserta datos
    Municipioslist.Insert(0, new Municipio  { mpio   = " ", descripcion  = "Select" });
    return Json(new SelectList(Municipioslist, "mpio", "descripcion"));

}

        public int CuentaRegs(string gburk , string burk)
        {
            return 0;
        }
            public JsonResult GetMunicipios2(string Region1)
        {
            List<Municipio> Municipioslist = new List<Municipio>();
            //traer datos
            Municipioslist = _context.Municipios.Where(a => a.region == Region1).ToList();
            //inserta datos
            Municipioslist.Insert(0, new Municipio { mpio = " ", descripcion = "Selec" });
            return Json(new SelectList(Municipioslist, "mpio", "descripcion"));

        }
        // </summary>
        // <param name="cat1"></param>
        // <returns></returns>


        // POST: Cat1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Correo_resp,Nombre_largo,Nombre,Pais,Rfc,Of_schp,Calle_num,Num_edif,Colonia,Poblac,Cod_post,Estado,Munic,Telefono,Tel_cel_respo,Skype_resp,Nombre_resp")] Cat1 cat1)
        {
            string mmun = cat1.Munic;
            cat1.Bukrs = cat1.Bukrs.PadLeft(4, '0');
            cat1.Gbukrs = cat1.Gbukrs.PadLeft(4, '0');
            ViewBag.GpoCiaG = cat1.Gbukrs;
            var items = new List<SelectListItem>();
            items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            List<Region1> region1list;
            // traer datos entityfram
            region1list = (from region1 in _context.Region1
                           select region1).ToList();

            //agregando los items a la lista
            ViewBag.ListofCategory = region1list;
            int cnt2 = (from m in _context.Cat1
                        where m.Gbukrs == cat1.Gbukrs && m.Bukrs == cat1.Bukrs
                        && m.Correo_resp == cat1.Correo_resp  && m.Id != cat1.Id
                        select m.Gbukrs).Count();
            if (cnt2 != 0)
            {
                ModelState.AddModelError("Correo_resp", "Registro Duplicado");
                cat1.Munic = mmun;

                return View(cat1);
            }

 

            //  ModelState.AddModelError("cursos", "Debe seleccionar por lo menos un curso");
            if (ModelState.IsValid)
            {
                _context.Add(cat1);
                await _context.SaveChangesAsync();
                TempData["message"] = "Cat1: " + cat1.Gbukrs + "  Cía: " + cat1.Bukrs + " - " +  cat1.Nombre;

                return RedirectToAction(nameof(Create));
                //return RedirectToAction(nameof(Index));
            }
            return View(cat1);
        }

        // GET: Cat1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

       


            if (id == null)
            {
                return NotFound();
            }

            var cat1 = await _context.Cat1.SingleOrDefaultAsync(m => m.Id == id);
            if (cat1 == null)
            {
                return NotFound();
            }
            var items = new List<SelectListItem>();
            items = DaBukrs(cat1.Gbukrs);
            ViewBag.DaBukrs = items.ToList();

            List<Region1> region1list = new List<Region1>();
            // traer datos entityfram
            region1list = (from region1 in _context.Region1
                           select region1).ToList();

            //agregando los items a la lista
           // region1list.Insert(0, new Region1 { rg = cat1.Estado , nombre = cat1.Munic  });
            //asignar category list to viewbag
            ViewBag.ListofCategory = region1list;
            List<Municipio> municlist = new List<Municipio>();
            // traer datos entityfram
            municlist = (from municipio in _context.Municipios
                         where municipio.region == cat1.Estado 
                           select municipio  ).ToList();
            //agregando los items a la lista
            // region1list.Insert(0, new Region1 { rg = cat1.Estado , nombre = cat1.Munic  });
            //asignar category list to viewbag
            ViewBag.ListofCategory = region1list;
            ViewBag.ListofMunicipios = municlist;
            return View(cat1);
        }

        // POST: Cat1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Correo_resp,Nombre_largo,Nombre,Pais,Rfc,Of_schp,Calle_num,Num_edif,Colonia,Poblac,Cod_post,Estado,Munic,Telefono,Tel_cel_respo,Skype_resp,Nombre_resp")] Cat1 cat1)
        {
            cat1.Bukrs = cat1.Bukrs.PadLeft(4, '0');
            cat1.Gbukrs = cat1.Gbukrs.PadLeft(4, '0');

            int cnt2 = (from m in _context.Cat1
                        where m.Gbukrs == cat1.Gbukrs && m.Bukrs == cat1.Bukrs
                        && m.Correo_resp == cat1.Correo_resp  && m.Id != cat1.Id
                        select m.Gbukrs).Count();
            if (cnt2 != 0)
            {
                ModelState.AddModelError("Correo_resp", "Registro Duplicado");
                return View(cat1);
            }


            if (id != cat1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cat1Exists(cat1.Id))
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
            return View(cat1);
        }

        // GET: Cat1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat1 = await _context.Cat1
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cat1 == null)
            {
                return NotFound();
            }

            return View(cat1);
        }

        // POST: Cat1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat1 = await _context.Cat1.SingleOrDefaultAsync(m => m.Id == id);
            _context.Cat1.Remove(cat1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cat1Exists(int id)
        {
            return _context.Cat1.Any(e => e.Id == id);
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

    }
}
