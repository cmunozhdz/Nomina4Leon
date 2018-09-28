using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class Region1
    {
        public Region1()
        {
        }


        public Region1(string Rg)
        {
            rg = Rg;
        }

       
        public int id { get; set; }

    
        [Display(Name = "Clave de Estado")]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "Teclee clave de Estado")]
        public string rg { get; set; }


        [Display(Name = "Estado")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Teclee el Estado")]
        public string nombre { get; set; }

     

    }
}
