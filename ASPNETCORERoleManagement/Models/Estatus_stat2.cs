using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class Estatus_stat2
    {

        public Estatus_stat2() { }



        public int Id { get; set; }

        [Display(Name = "GpoCia")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee el Grupo de Compañía")]
        public string Gbukrs { get; set; }
        
        [Display(Name = "Cia")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee la Compañía")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string Bukrs { get; set; }

        [Required]
       [RegularExpression(@"^[0-9]+[0-9]*$")]
        [Display(Name = "Estatus")]
        public int Estatus { get; set; }
        
        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Descripción  ")]
        public string Desc { get; set; }

     


    }
}
