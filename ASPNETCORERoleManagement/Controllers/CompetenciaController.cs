using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCORERoleManagement.Models;

namespace ASPNETCORERoleManagement.Controllers
{
    public class CompetenciaController : Controller
    {
        public IActionResult Index()
        {
            Competencia Competencia = new Competencia();
            Competencia.Id = 1;
            Competencia.Descripcion = "Liderazgo";
            Competencia.Generico = "1";
            Competencia.Bukrs = "1024";
            Competencia.Gbukrs = "1010";
            Competencia Competencia2 = new Competencia();
            Competencia2.Id = 1;
            Competencia2.Descripcion = "Liderazgo";
            Competencia2.Generico = "1";
            Competencia2.Bukrs = "1024";
            Competencia2.Gbukrs = "1010";




            List<Competencia> Competencias = new List<Competencia>();
            Competencias.Add(Competencia);
            Competencias.Add(Competencia2);


            return View(Competencias);
        }
    }
}