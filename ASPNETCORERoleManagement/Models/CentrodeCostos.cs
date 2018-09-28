using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class CentrodeCostos
    {

        public CentrodeCostos() { }

        public int Id { get; set; }

        [Display(Name = "GpoCia")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee el Grupo de Compañía")]
        public string Gbukrs { get; set; }

        [Display(Name = "Cia")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee la Compañía")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string Bukrs { get; set; }

        [Required]
        [Display(Name = "Centro de Costos")]
        [StringLength(10)]
        public string Cent_cost { get; set; }


        [Required]
        [StringLength(25, MinimumLength = 3)]
        [Display(Name = "Descripción  ")]
        public string Descrip { get; set; }

    }
}
