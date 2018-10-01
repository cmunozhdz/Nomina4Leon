using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class Competencias
    {

        public Competencias()
        {
            /*Constructor competencias.*/
        }
        public Competencias(int _Id , string _Competencia )
        {
            this.Id_Competencia = _Id;
            this.Competencia = _Competencia;

        }

        [Key]
        [Display(Name ="Id") ]
        public int Id_Competencia { get; set; }
        

        [Display(Name = "Competencia")]
        public string Competencia { get; set; }

        [Display(Name = "Descripción")]
        public string Competencias_Desc { get; set; }
        
        //[Display(Name = "Descripción")]
        //public string Competencias_Desc { get; set; }


        [Display(Name = "Generico")]
        public int Generico { get; set; }

        [Display(Name = "Sociedad")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee la Compañía")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string bukrs { get; set; }
        
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee el Grupo de Compañía")]
        public string gbukrs { get; set; }

    }
}
