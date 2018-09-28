using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class GpoCiaGlobal
    {

        public GpoCiaGlobal() { }


        [Display(Name = "Grupo Compañia")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee el Grupo de Compañía")]
        public string GpociaG { get; set; }



    }
}
