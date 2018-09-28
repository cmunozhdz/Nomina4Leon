using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCORERoleManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ASPNETCORERoleManagement.Models;
using Microsoft.AspNetCore.Http;

namespace ASPNETCORERoleManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GpoCiaGlobalController : Controller
    {
        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";
        private readonly ApplicationDbContext _context;

        public GpoCiaGlobalController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
       

       

            List<Cat1> region1list = new List<Cat1>();
            // traer datos entityfram
            region1list = (from cat1 in  _context.Cat1
                           select cat1).GroupBy(o => new { o.Gbukrs })
                           .Select(o => o.FirstOrDefault()).ToList() ;

            //agregando los items a la lista
            region1list.Insert(0, new Cat1 { Gbukrs = "0", Nombre = "Selecciona" });

            

          
            //asignar category list to viewbag
            ViewBag.ListofCategory = region1list.ToList();
                
            // HttpContext.Session.SetString(SessionGpoCia, "0000");
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            ViewData["GpoCiaG"] = HttpContext.Session.GetString(SessionGpoCia);
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string GpoCiaG)
        {
            string x = GpoCiaG;
            // gpocia.GpociaG  = gpocia.GpociaG.PadLeft(4, '0');


            //  ModelState.AddModelError("cursos", "Debe seleccionar por lo menos un curso");
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString(SessionGpoCia, x);
                ViewBag.GpoCiaG =  HttpContext.Session.GetString(SessionGpoCia);
              //  return RedirectToAction(nameof(Index));
            }

            var z = HttpContext.Session.GetString(SessionRegresa);
            HttpContext.Session.SetString(SessionRegresa, "");
            if (z == null || z == "")

            {

                return RedirectToAction(nameof(Index));

            } // 
            else
            {

                string[] separadas;

                separadas = z.Split(':');
                return RedirectToAction(separadas[0], separadas[1]);
            }


            //return View( );
        }




    }
}