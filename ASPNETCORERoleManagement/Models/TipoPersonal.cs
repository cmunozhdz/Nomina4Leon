using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class TipoPersonal
    {

        public TipoPersonal() { }

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
        [Display(Name = "Tipo Personal")]
        public int Tipo_pers { get; set; }

      


        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Descripción  ")]
        public string Descrip { get; set; }

  



    }
}
