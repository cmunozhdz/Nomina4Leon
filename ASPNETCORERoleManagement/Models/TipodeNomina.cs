using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class TipodeNomina
    {

        public TipodeNomina() { }

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
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Teclee el Tipo de Nómina")]
        [Display(Name = "Tipo de Nomina")]
        public string Tipo_nom { get; set; }

        [Required]
        [Display(Name = "Nomina")]
        [StringLength(2)]
        public string Nomina { get; set; }



        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Descripción  ")]
        public string Descrip { get; set; }




    }
}
