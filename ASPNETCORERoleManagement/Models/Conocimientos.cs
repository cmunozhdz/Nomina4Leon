using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCORERoleManagement.Models
{
    public class Conocimientos
    {
        [Required ]
        [Display(Name = "Id")]
        [Column(Order = 0)]
        [Key]
        public string Id_Conocimientos { get; set; }

        [Display(Name = "Descripción")]
        public string Conocimiento_Desc { get; set; }

        [Required]
        [Display(Name = "Sociedad")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee la Compañía")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string bukrs { get; set; }


        [Required]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee el Grupo de Compañía")]
        [Display(Name = "Grupo Compañia")]
        public string gbukrs { get; set; }


    }
}
