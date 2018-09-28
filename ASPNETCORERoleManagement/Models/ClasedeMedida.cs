using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class ClasedeMedida
    {

        public ClasedeMedida()
        {

        }
        
        public int Id { get; set; }
        
        [Display(Name = "GpoCia")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee el Grupo de Compañía")]
        public string Gbukrs { get; set; }
        [Display(Name = "Cia")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee la Compañía")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string Bukrs { get; set; }

        [Required]
        [Display(Name = "Movimiento")]
        [StringLength(2)]
        public string Massn { get; set; }

        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Descripción Movimiento ")]
        public string Massn_desc { get; set; }

        [Required]
        [Display(Name = "Tipo de Movimiento")]
        [StringLength(2)]
        public string Massg { get; set; }

        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Descripción del tipo de Movimiento ")]
        public string Massg_desc { get; set; }

     
    }
}
