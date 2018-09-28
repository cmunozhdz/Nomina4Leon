using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCORERoleManagement.Data;
using ASPNETCORERoleManagement.Models.PersonalViewModels;
using ASPNETCORERoleManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using ASPNETCORERoleManagement.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;

namespace ASPNETCORERoleManagement.Controllers

{
    [Authorize(Roles = "Admin")]
    public class Personal_agregarVMController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IRepositorioBukrs _bukrs;
        const string SessionGpoCia = "_GpoCia";
        const string SessionRegresa = "_RegresaA";

        public Personal_agregarVMController(ApplicationDbContext context, IRepositorioBukrs bukrs)
        {
            _context = context;
            _bukrs = bukrs;
        }

        // GET: Personal_agregarVM
        public async Task<IActionResult> Index()
        {

            ViewBag.Message = "";
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            if (ViewBag.GpoCiaG == null || ViewBag.GpoCiaG == "")
            {
                return View(await _context.Personal_agregarVM.ToListAsync());
            }
            else
            {
                var x = HttpContext.Session.GetString(SessionGpoCia);
                return View(await _context.Personal_agregarVM.Where(c => c.Gbukrs == x).ToListAsync());
            }
            //return View(await _context.Personal_agregarVM.ToListAsync());
        }

        // GET: Personal_agregarVM/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personal_agregarVM = await _context.Personal_agregarVM
                .SingleOrDefaultAsync(m => m.Id == id);
            if (personal_agregarVM == null)
            {
                return NotFound();
            }

            return View(personal_agregarVM);
        }

        // GET: Personal_agregarVM/Create
        public IActionResult Create()
        {
            Personal_agregarVM pc = new Personal_agregarVM();
            pc.Dia_1 = true;
            pc.Dia_2 = true;
            pc.Dia_3 = true;
            pc.Dia_4 = true;
            pc.Dia_5 = true;
            string dateInput = "Jan 1, 9999";
            DateTime parsedDate = DateTime.Parse(dateInput);
            pc.EndDa = parsedDate;
            pc.BegDa = DateTime.Now;
           // pc.Bukrs = "0";
            dateInput = "Mar 1,1975";
            parsedDate = DateTime.Parse(dateInput);
            pc.GbDat = parsedDate;
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            pc.Gbukrs = ViewBag.GpoCiaG;
            List<Divis> divislist = new List<Divis>();
            divislist = (from divis2 in _context.Divis
                         select divis2).ToList();
            //agregando los items a la lista
            divislist.Insert(0, new Divis { Id = 0, Descrip = "Select" });
            //asignar category list to viewbag
            ViewBag.ListofCategory = divislist;
            ViewBag.ListofTitles = _bukrs.GetTitle();
            ViewBag.ListofClasedeContrato = _bukrs.GetClasedeContrato();
            ViewBag.ListofClavedeSexo = _bukrs.GetClavedeSexo();
            ViewBag.ListofRegion1 = _bukrs.GetRegion1();
            ViewBag.ListofEstado = _bukrs.GetRegion1();
            ViewBag.ListofTipoPago = _bukrs.GetTipoPago();
            ViewBag.ListofPerPru = _bukrs.GetPeriodoPrueba();

            if (ViewBag.GpoCiaG == null)
            {
                HttpContext.Session.SetString(SessionRegresa, "Create:Personal_agregarVM");
                return RedirectToAction("Index", "GpoCiaGlobal");
                //return Redirect("GpoCiaGlobal/Index");
            }
            else
            {
                HttpContext.Session.SetString(SessionRegresa, "");

            }
            var items = new List<SelectListItem>();
            items = _bukrs.DaBukrs2(ViewBag.GpoCiaG);

            //items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();



            return View(pc);
        }

        // POST: Personal_agregarVM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gbukrs,Bukrs,Pernr,Subty,Seqnr,BegDa,EndDa,Title,Vorna,Nachn,Nach2,IntMassgid,Estatus,Tipo_pers,Area_pers,Divi,Subdivis,Nomina,Cent_cost,Orgeh,Plans,Stell,Cttyp,Prbzt,Prbeh,Curp,Gesch,GbDat,Gblnd,Gbdep,Gbort,Natio,Usrty1,Usrid1,Ine,Rfc,Licencia,Issste,Afore,Stras,Colonia,Poblac,Cod_post,Estado,Munic,Land1,Telnr,Hrs_Trab,Hr_Entrada,Hr_Salida,Hr_Pausa1,Hr_Pausa2,Dia_1,Dia_2,Dia_3,Dia_4,Dia_5,Dia_6,Dia_7,Sueldo_dia,Sueldo_mens,Sdo_hora,Tipo_pago,Banco,Pais,Cuenta,Plaza_cta,Estado1,Clabe_banco")] Personal_agregarVM personal_agregarVM)
 //             public async Task<IActionResult> Create( Personal_agregarVM personal_agregarVM)

        {
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);

   





            Personal persona1 = new Personal();
            persona1.Bukrs = personal_agregarVM.Bukrs;
            persona1.Gbukrs = personal_agregarVM.Gbukrs;
            persona1.Aedtm = DateTime.Now;
            persona1.BegDa = personal_agregarVM.BegDa;
            persona1.EndDa = personal_agregarVM.EndDa;
            persona1.Nach2 = personal_agregarVM.Nach2;
            persona1.Nachn = personal_agregarVM.Nachn;
            persona1.Vorna = personal_agregarVM.Vorna;
            persona1.Pernr = personal_agregarVM.Pernr;
            persona1.Seqnr = personal_agregarVM.Seqnr;
            persona1.Subty = personal_agregarVM.Subty;
            persona1.Uname = "nombre";  //UserManager.GetUserName(User)

            persona1.Cname = persona1.Vorna.ToUpper() + " " + persona1.Nachn.ToUpper() + " " + persona1.Nach2.ToUpper();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userNa = User.FindFirstValue(ClaimTypes.Name);





            persona1.Uname = userNa;



            IT0 personait0 = new IT0();
            personait0.BegDa = persona1.BegDa;
            personait0.EndDa = persona1.EndDa;
            personait0.Bukrs = persona1.Bukrs;
            personait0.Gbukrs = persona1.Gbukrs;
            personait0.Aedtm = persona1.Aedtm;
            personait0.Estatus = personal_agregarVM.Estatus;
            // traer los datos desde la base de datos
            //IT0 tablait0 = new IT0();
           // int x = Convert.ToInt16(personal_agregarVM.IdMassg);
            var tablait0 = await _context.ClasedeMedida.SingleOrDefaultAsync(m => m.Id == personal_agregarVM.IntMassgid);
            personait0.Massg = tablait0.Massg;
            personait0.Massn = tablait0.Massn;
            personait0.Pernr = persona1.Pernr;
            personait0.Seqnr = persona1.Seqnr;
            personait0.Subty = persona1.Subty;
            personait0.Uname = persona1.Uname;


            IT1 pit1 = new IT1();
            pit1.Uname = persona1.Uname;
            pit1.Tipo_pers = personal_agregarVM.Tipo_pers;
            pit1.Subty = persona1.Subty;
            pit1.Subdivis = personal_agregarVM.Subdivis;
            pit1.Stell = personal_agregarVM.Stell;
            pit1.Seqnr = personal_agregarVM.Seqnr;
            pit1.Plans = personal_agregarVM.Plans;
            pit1.Gbukrs = persona1.Gbukrs;
            pit1.BegDa = persona1.BegDa;
            pit1.Bukrs = persona1.Bukrs;
            pit1.Nomina = personal_agregarVM.Nomina;
            pit1.Aedtm = persona1.Aedtm;
            pit1.Area_pers = personal_agregarVM.Area_pers;
            pit1.Cent_cost = personal_agregarVM.Cent_cost;
            pit1.Divi = personal_agregarVM.Divi;
            pit1.EndDa = persona1.EndDa;
            pit1.Pernr = persona1.Pernr;
            pit1.Orgeh = personal_agregarVM.Orgeh;
          

            IT16 pit16 = new IT16();

            pit16.Prbeh = personal_agregarVM.Prbeh;
            pit16.Pernr = personal_agregarVM.Pernr;
            pit16.Prbzt = personal_agregarVM.Prbzt;
            pit16.Seqnr = personal_agregarVM.Seqnr;
            pit16.Gbukrs = persona1.Gbukrs;
            pit16.Aedtm = persona1.Aedtm;
            pit16.BegDa = persona1.BegDa;
            pit16.Bukrs = persona1.Bukrs;
            pit16.Cttyp = personal_agregarVM.Cttyp;
            pit16.EndDa = persona1.EndDa;
            pit16.Uname = persona1.Uname;
            pit16.Subty = persona1.Subty;


            IT2_185_105 pit2 = new IT2_185_105();



            pit2.Seqnr = personal_agregarVM.Seqnr;
            pit2.Gbukrs = persona1.Gbukrs;
            pit2.Aedtm = persona1.Aedtm;
            pit2.BegDa = persona1.BegDa;
            pit2.Bukrs = persona1.Bukrs;
            pit2.Title = personal_agregarVM.Title;
            pit2.EndDa = persona1.EndDa;
            pit2.Uname = persona1.Uname;
            pit2.Subty = persona1.Subty;
            pit2.Pernr = persona1.Pernr;

            pit2.Afore = personal_agregarVM.Afore;
            pit2.Curp = personal_agregarVM.Curp;
            pit2.GbDat = personal_agregarVM.GbDat;
            pit2.Gbdep = personal_agregarVM.Gbdep;
            pit2.Gblnd = personal_agregarVM.Gblnd;
            pit2.Gbort = personal_agregarVM.Gbort;
            pit2.Gesch = personal_agregarVM.Gesch;
            pit2.Ine = personal_agregarVM.Ine;
            pit2.Issste = personal_agregarVM.Issste;
            pit2.Licencia = personal_agregarVM.Licencia;
            pit2.Natio = personal_agregarVM.Natio;
            pit2.Rfc = personal_agregarVM.Rfc;
            pit2.Usrid1 = personal_agregarVM.Usrid1;
            pit2.Usrty1 = personal_agregarVM.Usrty1;


            IT6 pit6 = new IT6();

            pit6.Aedtm = persona1.Aedtm;
            pit6.BegDa = persona1.BegDa;
            pit6.Bukrs = persona1.Bukrs;
            pit6.EndDa = persona1.EndDa;
            pit6.Uname = persona1.Uname;
            pit6.Subty = persona1.Subty;
            pit6.Seqnr = personal_agregarVM.Seqnr;
            pit6.Gbukrs = persona1.Gbukrs;
            pit6.Pernr = persona1.Pernr;

            pit6.Colonia = personal_agregarVM.Colonia;
            pit6.Cod_post = personal_agregarVM.Cod_post;
            pit6.Estado = personal_agregarVM.Estado;
            pit6.Land1 = personal_agregarVM.Land1;
            pit6.Munic = personal_agregarVM.Munic;
            pit6.Poblac = personal_agregarVM.Poblac;
            pit6.Stras = personal_agregarVM.Stras;
            pit6.Telnr = personal_agregarVM.Telnr;


            IT7 pit7 = new IT7();
            pit7.Aedtm = persona1.Aedtm;
            pit7.BegDa = persona1.BegDa;
            pit7.Bukrs = persona1.Bukrs;
            pit7.EndDa = persona1.EndDa;
            pit7.Uname = persona1.Uname;
            pit7.Subty = persona1.Subty;
            pit7.Seqnr = personal_agregarVM.Seqnr;
            pit7.Gbukrs = persona1.Gbukrs;
            pit7.Pernr = persona1.Pernr;

            if (personal_agregarVM.Dia_1)
            { pit7.Dia_1 = 1; }
            else
            { pit7.Dia_1 = 0; }

            if (personal_agregarVM.Dia_2)
            { pit7.Dia_2 = 1; }
            else
            { pit7.Dia_2 = 0; }
            if (personal_agregarVM.Dia_3)
            { pit7.Dia_3 = 1; }
            else
            { pit7.Dia_3 = 0; }
            if (personal_agregarVM.Dia_4)
            { pit7.Dia_4 = 1; }
            else
            { pit7.Dia_4 = 0; }
            if (personal_agregarVM.Dia_5)
            { pit7.Dia_5 = 1; }
            else
            { pit7.Dia_5 = 0; }
            if (personal_agregarVM.Dia_6)
            { pit7.Dia_6 = 1; }
            else
            { pit7.Dia_6 = 0; }
            if (personal_agregarVM.Dia_7)
            { pit7.Dia_7 = 1; }
            else
            { pit7.Dia_7 = 0; }

            pit7.Hrs_Trab = personal_agregarVM.Hrs_Trab;
            pit7.Hr_Entrada = personal_agregarVM.Hr_Entrada;
            pit7.Hr_Pausa1 = personal_agregarVM.Hr_Pausa1;
            pit7.Hr_Pausa2 = personal_agregarVM.Hr_Pausa2;
            pit7.Hr_Salida = personal_agregarVM.Hr_Salida;

            IT8 pit8 = new IT8();
            pit8.Aedtm = persona1.Aedtm;
            pit8.BegDa = persona1.BegDa;
            pit8.Bukrs = persona1.Bukrs;
            pit8.EndDa = persona1.EndDa;
            pit8.Uname = persona1.Uname;
            pit8.Subty = persona1.Subty;
            pit8.Seqnr = personal_agregarVM.Seqnr;
            pit8.Gbukrs = persona1.Gbukrs;
            pit8.Pernr = persona1.Pernr;

            pit8.Sdo_hora = personal_agregarVM.Sdo_hora;
            pit8.Sueldo_dia = personal_agregarVM.Sueldo_dia;
            pit8.Sueldo_mens = personal_agregarVM.Sueldo_mens;

            IT9 pit9 = new IT9();
            pit9.Aedtm = persona1.Aedtm;
            pit9.BegDa = persona1.BegDa;
            pit9.Bukrs = persona1.Bukrs;
            pit9.EndDa = persona1.EndDa;
            pit9.Uname = persona1.Uname;
            pit9.Subty = persona1.Subty;
            pit9.Seqnr = personal_agregarVM.Seqnr;
            pit9.Gbukrs = persona1.Gbukrs;
            pit9.Pernr = persona1.Pernr;

            pit9.Banco = personal_agregarVM.Banco;
            pit9.Clabe_banco = personal_agregarVM.Clabe_banco;
            pit9.Cuenta = personal_agregarVM.Cuenta;
            pit9.Estado = personal_agregarVM.Estado1;
            pit9.Pais = personal_agregarVM.Pais;
            pit9.Plaza_cta = personal_agregarVM.Plaza_cta;
            pit9.Tipo_pago = personal_agregarVM.Tipo_pago;



 



            //personait0.Massg = await _context.ClasedeMedida.SingleOrDefaultAsync(m => m.Id == x);
            //persona1.Cname = personal_agregarVM.Vorna.ToUpper() + " " + personal_agregarVM.Nachn.ToUpper() + " " + personal_agregarVM.Nach2.ToUpper();

            if (ModelState.IsValid)
            {

                //tm2 = db.tblModel2.Add(tm2);  tm2 equivale a personal...
                // await db.SaveChangesAsync();
                // return tm2.ID;
                try
                {
                    _context.Add(persona1);
                    var idx = await _context.SaveChangesAsync();
                    //persona1.Id = idx;
                    idx = persona1.Id;

                    //este despues de grabar
                    personait0.PersonalId = idx;
                    pit1.PersonalId = idx;
                    pit16.PersonalId = idx;
                    pit2.PersonalId = idx;
                    pit6.PersonalId = idx;
                    pit7.PersonalId = idx;
                    pit8.PersonalId = idx;
                    pit9.PersonalId = idx;
                    _context.Add(personait0);
                    await _context.SaveChangesAsync();
             
                    _context.Add(pit1);
                     await _context.SaveChangesAsync();
                    _context.Add(pit16);
                    await _context.SaveChangesAsync();
                    _context.Add(pit2);
                    await _context.SaveChangesAsync();
                    _context.Add(pit6);
                    await _context.SaveChangesAsync();
                    _context.Add(pit7);
                    await _context.SaveChangesAsync();
                    _context.Add(pit8);
                    await _context.SaveChangesAsync();

                    _context.Add(pit9);
                    await _context.SaveChangesAsync();

                    //return RedirectToAction(nameof(Index));
                    //return Redirect("PersonalInfotipos/Index");
                    return RedirectToAction("Index", "PersonalInfotipos");
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Imposible grabar. " +
                       "Intente de nuevo, si el problema persiste, " +
"comuniquese con el administrador del sistema.");
                }
                
            }
            var items = new List<SelectListItem>();
            items = _bukrs.DaBukrs2(ViewBag.GpoCiaG);

            //items = DaBukrs(ViewBag.GpoCiaG);
            ViewBag.DaBukrs = items.ToList();
            ViewBag.ListofTitles = _bukrs.GetTitle();
            ViewBag.ListofClasedeContrato = _bukrs.GetClasedeContrato();
            ViewBag.ListofClavedeSexo = _bukrs.GetClavedeSexo();
            ViewBag.ListofRegion1 = _bukrs.GetRegion1();
            ViewBag.ListofEstado = _bukrs.GetRegion1();
            ViewBag.ListofTipoPago = _bukrs.GetTipoPago();
            ViewBag.ListofPerPru = _bukrs.GetPeriodoPrueba();
            return View(personal_agregarVM);
        }

        // GET: Personal_agregarVM/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var personal_agregrVM = new Personal_agregarVM();
            var personal_agregarVM = await _context.Personals.SingleOrDefaultAsync(m => m.Id == id);
            if (personal_agregarVM == null)
            {
                return NotFound();
            }

            return View(personal_agregarVM);
        }

        // POST: Personal_agregarVM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gbukrs,Bukrs,Pernr,Subty,Seqnr,BegDa,EndDa,Title,Vorna,Nachn,Nach2,IntMassgid,Estatus,Estatus2,Tipo_pers,Area_pers,Divi,Subdivis,Nomina,Cent_cost,Orgeh,Plans,Stell,Cttyp,Prbzt,Prbeh,Curp,Gesch,GbDat,Gblnd,Gbdep,Gbort,Natio,Usrty1,Usrid1,Ine,Rfc,Licencia,Issste,Afore,Stras,Colonia,Poblac,Cod_post,Estado,Munic,Land1,Telnr,Hrs_Trab,Hr_Entrada,Hr_Salida,Hr_Pausa1,Hr_Pausa2,Dia_1,Dia_2,Dia_3,Dia_4,Dia_5,Dia_6,Dia_7,Sueldo_dia,Sueldo_mens,Sdo_hora,Tipo_pago,Banco,Pais,Cuenta,Plaza_cta,Estado1,Clabe_banco")] Personal_agregarVM personal_agregarVM)
        {
            if (id != personal_agregarVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personal_agregarVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Personal_agregarVMExists(personal_agregarVM.Id))
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
            return View(personal_agregarVM);
        }

        // GET: Personal_agregarVM/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personal_agregarVM = await _context.Personal_agregarVM
                .SingleOrDefaultAsync(m => m.Id == id);
            if (personal_agregarVM == null)
            {
                return NotFound();
            }

            return View(personal_agregarVM);
        }

        // POST: Personal_agregarVM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personal_agregarVM = await _context.Personal_agregarVM.SingleOrDefaultAsync(m => m.Id == id);
            _context.Personal_agregarVM.Remove(personal_agregarVM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Personal_agregarVMExists(int id)
        {
            return _context.Personal_agregarVM.Any(e => e.Id == id);
        }


        public JsonResult GetClasedeMedida(string idp)
        {
            List<ClasedeMedida> DivisionList = new List<ClasedeMedida>();
            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            //inserta datos
                       
            var modifiedData = new List<SelectListItem>();
            modifiedData = _bukrs.GetClasedeMedida(idp, x);
            return Json(modifiedData);
        }

        public JsonResult GetDivisions(string idp)
        {
            List<Divis> DivisionList = new List<Divis>();
            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            //inserta datos
            DivisionList = _bukrs.GetDivisions(idp, x);
            return Json(new SelectList(DivisionList, "Divi", "Descrip"));
           
        }
   

        public JsonResult GetEstatus(string idp)
        {
    
            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            //inserta datos

            List<Estatus_stat2> modifiedData = new List<Estatus_stat2>();
            modifiedData = _bukrs.GetEstatus1(idp, x);
            return Json(new SelectList(modifiedData, "Estatus", "Desc"));
          //  return Json(modifiedData);
        }


    


        public JsonResult GetTipoPer(string bukrs)
        {

            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            //inserta datos

            var modifiedData = new List<SelectListItem>();
            modifiedData = _bukrs.GetTipoPersonal(bukrs, x);
            return Json(modifiedData);
        }


        public JsonResult GetAreaPer(string bukrs, int tipoper)
        {

            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            //inserta datos

            var modifiedData = new List<SelectListItem>();
            modifiedData = _bukrs.GetAreaPer(bukrs, x, tipoper);
            return Json(modifiedData);
        }
  

        public JsonResult GetSubdivis(string bukrs, string divis)
        {

            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            //inserta datos

            var modifiedData = new List<SelectListItem>();
            modifiedData = _bukrs.GetSubdivis(bukrs, x, divis);
            return Json(modifiedData);
        }

        public JsonResult GetNomina(string idp)
        {
            List<TipodeNomina> DivisionList = new List<TipodeNomina>();
            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            //inserta datos
            DivisionList = _bukrs.GetNomina(idp, x);
            return Json(new SelectList(DivisionList, "Nomina", "Descrip"));

        }

        public JsonResult GetCentrodeCostos(string idp)
        {
            List<CentrodeCostos> DivisionList = new List<CentrodeCostos>();
            //traer datos
            ViewBag.GpoCiaG = HttpContext.Session.GetString(SessionGpoCia);
            string x = ViewBag.GpoCiaG;
            //inserta datos
            DivisionList = _bukrs.GetCentrodeCostos(idp, x);
            return Json(new SelectList(DivisionList, "Cent_cost", "Descrip"));

        }

     


    }
}
