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
        [Display(Name = "Id")]
        [Key]
        [Column(Order = 0)]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id_Competencia { get; set; }

        [Key]
        [Column(Order = 1)]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [Display(Name = "Competencia")]
        //[Key]
        //[Column(Order = 2)]

        public string Competencia { get; set; }

        [Display(Name = "Descripción")]
        public string Competencias_Desc { get; set; }





        [Display(Name = "Generico")]
        public int Generico { get; set; }

        [Display(Name = "Sociedad")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee la Compañía")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string bukrs { get; set; }

        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee el Grupo de Compañía")]
        [Display(Name = "Grupo Compañia")]
        public string gbukrs { get; set; }

    }
}
