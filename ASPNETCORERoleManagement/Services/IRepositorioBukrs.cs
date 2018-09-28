using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCORERoleManagement.Models;

namespace ASPNETCORERoleManagement.Services
{
    public interface IRepositorioBukrs
    {
         List<SelectListItem> DaBukrs2(string gbukrsp);

        List<Divis> GetDivisions(string idp, string gbukrs);

        List<SelectListItem> DaMassg1(string gbukrsp, string bukrs, string massn);
        List<SelectListItem> GetClasedeMedida(string bukrs, string gbukrs);
        List<SelectListItem> GetTitle();
        List<Estatus_stat2> GetEstatus1(string bukrs, string gbukrs);
       
        List<SelectListItem> GetTipoPersonal(string bukrs, string gbukrs);

        List<SelectListItem> GetAreaPer(string bukrs, string gbukrs, int tipoper);
        List<SelectListItem> GetSubdivis(string bukrs, string gbukrs, string divi);
        List<TipodeNomina> GetNomina(string idp, string gbukrs);
        List<CentrodeCostos> GetCentrodeCostos(string bukrs, string gbukrs);
        List<SelectListItem> GetClasedeContrato();
        List<Region1> GetRegion1();

        List<SelectListItem> GetClavedeSexo();
        List<SelectListItem> GetMunicipios(string region1);
        List<CheckboxItem> GetSemana();
        List<SelectListItem> GetTipoPago();
        List<SelectListItem> GetPeriodoPrueba();
        List<SelectListItem> DaClasedeMedida(string gbukrsp, string bukrs);
        List<SelectListItem> GetClasedeFecha();
    }
}

