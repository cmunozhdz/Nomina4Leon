using ASPNETCORERoleManagement.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Services
{
    public class FuncionesVarias
    {

        private readonly ApplicationDbContext _context;

        public FuncionesVarias(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        public List<SelectListItem> DaBukrs(string gbukrsp)
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
