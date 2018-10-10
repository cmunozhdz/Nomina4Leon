using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class Competencias
    {
        [Key]
        [Display(Name = "Id")]
        
        [Column(Order = 0)]
        [Required ]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Id. es obligatorio")]
        public string  Id_Competencia { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Competencias_Desc { get; set; }


        [Required]
        [Display(Name = "Generico")]
        public int Generico { get; set; }

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
