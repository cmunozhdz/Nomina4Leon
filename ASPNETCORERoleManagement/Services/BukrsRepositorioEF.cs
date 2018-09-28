using ASPNETCORERoleManagement.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCORERoleManagement.Models;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORERoleManagement.Services
{
    public class BukrsRepositorioEF : IRepositorioBukrs
    {
        const string SessionGpoCia = "_GpoCia";
        public BukrsRepositorioEF(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;

        }

        public ApplicationDbContext DbContext { get; }

        public List<SelectListItem> DaBukrs2(string gbukrsp)
        {

            // traer datos entityfram
            List<string> bukrslist = new List<string>();
            IEnumerable<string> bukrslist2 = new List<string>();
            var items = new List<SelectListItem>();
            //agregando los items a la lista

            // traer datos entityfram
            bukrslist = (from cat13 in DbContext.Cat1
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


        public List<Divis> GetDivisions(string idp, string gbukrs)
        {
            List<Divis> DivisionList = new List<Divis>();
            //traer datos
           // ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
           // string x = ViewBag.GpoCiaG;
           //string x = HttpContext
            DivisionList = (from divisiones in DbContext.Divis
                            where divisiones.Bukrs == idp && divisiones.Gbukrs == gbukrs
                            select divisiones).ToList();
            //inserta datos
            DivisionList.Insert(0, new Divis { Divi = "0", Descrip = "Select" });
            return DivisionList;
            //return Json(new SelectList(DivisionList, "Divi", "Descrip"));
        }


        public List<SelectListItem> DaMassg1(string gbukrsp, string bukrs, string massn)
        {

            // traer datos entityfram
            List<ClasedeMedida> massglist = new List<ClasedeMedida>();
            IEnumerable<string> massglist2 = new List<string>();
            var items = new List<SelectListItem>();
            //agregando los items a la lista

            // traer datos entityfram
            massglist = (from clasedeMedida in DbContext.ClasedeMedida
                         where clasedeMedida.Gbukrs == gbukrsp && clasedeMedida.Bukrs==bukrs && clasedeMedida.Massn==massn
                         select clasedeMedida).ToList();
            //massglist2 = massglist.Distinct();
            items.Add(new SelectListItem
            {
                Text = "Selec",
                Value = "0"
            });

            foreach (var lista1 in massglist)
            {

                items.Add(new SelectListItem
                {
                    Text = lista1.Massg_desc,
                    Value = lista1.Massg
                });
            }
            return (items.ToList());
            //var items = new List<SelectListItem>();
        }



        public List<SelectListItem> GetClasedeMedida(string bukrs, string gbukrs )
        {
            //value = id text = nombre
            List<ClasedeMedida> ClaseMedida = new List<ClasedeMedida>();
            //traer datos
            ClaseMedida = (from divisiones in DbContext.ClasedeMedida
                            where divisiones.Bukrs == bukrs && divisiones.Gbukrs == gbukrs
                            select divisiones).ToList();
            //inserta datos

            ClaseMedida.Insert(0, new ClasedeMedida { Id = 0, Massg_desc = "Selecc", Massn_desc = " pba" });
            var modifiedData =  ClaseMedida.Select(xy => new
            {
                id= xy.Id,
                text = (xy.Massg_desc).PadRight(15, ' ') + "|" + (xy.Massn_desc).PadLeft(15, ' ')
            });
            var item = new SelectList(modifiedData, "id", "text");
            return ( item.ToList());
        }


        public List<SelectListItem> GetTipoPersonal(string bukrs, string gbukrs)
        {
            //value = id text = nombre
            List<TipoPersonal> ClaseMedida = new List<TipoPersonal>();
            //traer datos
            ClaseMedida = (from divisiones in DbContext.TipoPersonal
                           where divisiones.Bukrs == bukrs && divisiones.Gbukrs == gbukrs
                           select divisiones).ToList();
            //inserta datos

            ClaseMedida.Insert(0, new TipoPersonal { Tipo_pers = 0, Descrip = "Selecc" });
            var modifiedData = ClaseMedida.Select(xy => new
            {
                id = xy.Tipo_pers,
                text = (xy.Descrip)
            });
            var item = new SelectList(modifiedData, "id", "text");
            return (item.ToList());
        }



        public List<SelectListItem> GetTitle()
        {
            var items2 = new List<SelectListItem>();
            var types = new List<SelectListItem>();
           
            items2.Add(new SelectListItem(){ Text = "Sr",       Value = "1"        });
            items2.Add(new SelectListItem
            {
                Value = "2",
                Text = "Sra"
            });
            items2.Add(new SelectListItem
            {
                Value = "3",
                Text = "Srta"
            });
            return items2.ToList();
        }

        public List<Estatus_stat2> GetEstatus1(string bukrs, string gbukrs)
        {
            //value = id text = nombre
            List<Estatus_stat2> Estatus = new List<Estatus_stat2>();
            //traer datos
            Estatus = (from divisiones in DbContext.Estatus_Stat2
                           where divisiones.Bukrs == bukrs && divisiones.Gbukrs == gbukrs
                           select divisiones).ToList();
            //inserta datos

            Estatus.Insert(0, new Estatus_stat2 { Estatus = 0, Desc = "Selec" });
            var modifiedData = Estatus.Select(xy => new
            {
                id = xy.Estatus,
                text = (xy.Desc)
            });
            var item = new SelectList(modifiedData, "id", "text");
            //return (item.ToList());
            return Estatus;
        }

  
        public List<SelectListItem> GetAreaPer(string bukrs, string gbukrs, int tipoper)
        {
            //value = id text = nombre
            List<AreaPers> Estatus = new List<AreaPers>();
            //traer datos
            Estatus = (from divisiones in DbContext.AreaPers
                       where divisiones.Bukrs == bukrs && divisiones.Gbukrs == gbukrs && divisiones.Tipo_pers== tipoper
                       select divisiones).ToList();
            //inserta datos

            Estatus.Insert(0, new AreaPers { Area_pers = "00", Descrip = "Selecc" });
            var modifiedData = Estatus.Select(xy => new
            {
                id = xy.Area_pers,
                text = (xy.Descrip)
            });
            var item = new SelectList(modifiedData, "id", "text");
            return (item.ToList());
        }


        public List<SelectListItem> GetSubdivis(string bukrs, string gbukrs, string divi)
        {
            //value = id text = nombre
            List<Subdivision> Estatus = new List<Subdivision>();
            //traer datos
            Estatus = (from divisiones in DbContext.Subdivision
                       where divisiones.Bukrs == bukrs && divisiones.Gbukrs == gbukrs && divisiones.Divi == divi
                       select divisiones).ToList();
            //inserta datos

            Estatus.Insert(0, new Subdivision { Subdivis = "0", Descrip = "Selecc" });
            var modifiedData = Estatus.Select(xy => new
            {
                id = xy.Subdivis,
                text = (xy.Descrip)
            });
            var item = new SelectList(modifiedData, "id", "text");
            return (item.ToList());
        }

        public List<TipodeNomina> GetNomina(string bukrs, string gbukrs)
        {
            List<TipodeNomina> DivisionList = new List<TipodeNomina>();
            //traer datos
            // ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            // string x = ViewBag.GpoCiaG;
            //string x = HttpContext
            DivisionList = (from divisiones in DbContext.TipodeNomina
                            where divisiones.Bukrs == bukrs && divisiones.Gbukrs == gbukrs
                            select divisiones).ToList();
            //inserta datos
            DivisionList.Insert(0, new TipodeNomina { Nomina = "00", Descrip = "Selec" });
            return DivisionList;
            //return Json(new SelectList(DivisionList, "Divi", "Descrip"));
        }

        public List<CentrodeCostos> GetCentrodeCostos(string bukrs, string gbukrs)
        {
            List<CentrodeCostos> DivisionList = new List<CentrodeCostos>();
            //traer datos
            // ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            // string x = ViewBag.GpoCiaG;
            //string x = HttpContext
            DivisionList = (from divisiones in DbContext.CentrodeCostos
                            where divisiones.Bukrs == bukrs && divisiones.Gbukrs == gbukrs
                            select divisiones).ToList();
            //inserta datos
            DivisionList.Insert(0, new CentrodeCostos { Cent_cost = "0", Descrip = "Selec" });
            return DivisionList;
            //return Json(new SelectList(DivisionList, "Divi", "Descrip"));
        }

        public List<SelectListItem> GetClasedeContrato()
        {
            var items2 = new List<SelectListItem>();
           
            items2.Add(new SelectListItem() { Value = "1", Text = "Definido" });
            items2.Add(new SelectListItem
            {
                Value = "2",
                Text = "Indefinido"
            });
           
            return items2.ToList();
        }

        public List<Region1> GetRegion1()
        {
            List<Region1> DivisionList = new List<Region1>();

        
            //agregando los items a la lista
            //asignar category list to viewbag
           
            //traer datos
            // ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            // string x = ViewBag.GpoCiaG;
            //string x = HttpContext
            DivisionList = (from divisiones in DbContext.Region1
                            select divisiones).ToList();
            //inserta datos
            DivisionList.Insert(0, new Region1 {  rg = "0",  nombre = "Selec" });
            return DivisionList;
            //return Json(new SelectList(DivisionList, "Divi", "Descrip"));
        }

        public List<SelectListItem> GetClavedeSexo()
        {
            var items2 = new List<SelectListItem>();

            items2.Add(new SelectListItem() { Value = "1", Text = "Masculino" });
            items2.Add(new SelectListItem
            {
                Value = "2",
                Text = "Femenino"
            });
            items2.Add(new SelectListItem
            {
                Value = "3",
                Text = "Indefinido"
            });
            return items2.ToList();
        }
        public List<SelectListItem> GetTipoPago()
        {
            var items2 = new List<SelectListItem>();

            items2.Add(new SelectListItem() { Value = "T", Text = "Transferencia" });
            items2.Add(new SelectListItem
            {
                Value = "C",
                Text = "Cheque"
            });
            items2.Add(new SelectListItem
            {
                Value = "E",
                Text = "Efectivo"
            });
            return items2.ToList();
        }

        public List<SelectListItem> GetPeriodoPrueba()
        {
            var items2 = new List<SelectListItem>();

            items2.Add(new SelectListItem() { Value = "1", Text = "Dias" });
            items2.Add(new SelectListItem
            {
                Value = "2",
                Text = "Semanas"
            });
            items2.Add(new SelectListItem
            {
                Value = "3",
                Text = "Meses"
            });
            return items2.ToList();
        }

        public List<SelectListItem> GetClasedeFecha()
        {
            var items2 = new List<SelectListItem>();

            items2.Add(new SelectListItem() { Value = "1", Text = "Antig" });
            items2.Add(new SelectListItem
            {
                Value = "2",
                Text = "Vacaciones"
            });
            items2.Add(new SelectListItem
            {
                Value = "3",
                Text = "Ficha Técnica"
            });
            return items2.ToList();
        }
        public List<SelectListItem> GetMunicipios(string region1)
        {
            //value = id text = nombre
            List<Municipio> Estatus = new List<Municipio>();
            //traer datos
            Estatus = (from divisiones in DbContext.Municipios
                       where divisiones.region== region1
                       select divisiones).ToList();
            //inserta datos

            Estatus.Insert(0, new Municipio {  mpio = "0", descripcion = "Selecc" });
            var modifiedData = Estatus.Select(xy => new
            {
                id = xy.mpio,
                text = (xy.descripcion)
            });
            var item = new SelectList(modifiedData, "id", "text");
            return (item.ToList());
        }


        public List<CheckboxItem> GetSemana()
        {
            List<CheckboxItem> checkboxes = new List<CheckboxItem>();
            //inserta datos
            checkboxes.Insert(0, new CheckboxItem { Id = 1, Title="Lun", IsChecked=false });
            checkboxes.Insert(1, new CheckboxItem { Id = 2, Title = "Mar", IsChecked = false });
            checkboxes.Insert(2, new CheckboxItem { Id = 3, Title = "Mie", IsChecked = false });
            checkboxes.Insert(3, new CheckboxItem { Id = 4, Title = "Jue", IsChecked = false });
            checkboxes.Insert(4, new CheckboxItem { Id = 5, Title = "Vie", IsChecked = false });
            checkboxes.Insert(5, new CheckboxItem { Id = 6, Title = "Sab", IsChecked = false });
            checkboxes.Insert(6, new CheckboxItem { Id = 7, Title = "Dom", IsChecked = false });
            return checkboxes;
            //return Json(new SelectList(DivisionList, "Divi", "Descrip"));
        }

        public List<SelectListItem> DaClasedeMedida(string gbukrsp, string bukrs)
        {

            // traer datos entityfram
           // List<SelectListItem> ctocostos = new List<SelectListItem>();
            IEnumerable<string> bukrslist2 = new List<string>();
            var items = new List<SelectListItem>();
            //agregando los items a la lista

            // traer datos entityfram
            var clasemedida = (from cat13 in DbContext.ClasedeMedida
                         where cat13.Gbukrs == gbukrsp && cat13.Bukrs== bukrs
                         group cat13 by cat13.Massn into newClase
                         select newClase);
            //bukrslist2 = ctocostos.Distinct();
            items.Add(new SelectListItem
            {
                Text = "Selecc",
                Value = "0"
            });

            foreach (var lista1 in clasemedida)
            {
                foreach (var clase1 in lista1) {
                    items.Add(new SelectListItem
                    {
                        Text = clase1.Massn_desc,
                         Value = clase1.Massn
                        });


                }
            }
        
            return (items.ToList());

            //var items = new List<SelectListItem>();

        }



    }
}
