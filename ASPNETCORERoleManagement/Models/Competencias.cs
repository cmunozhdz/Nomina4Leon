using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class Competencias
    {
        public Competencias() { }

        public Competencias(int Id_Competencia) {
            this.Id_Competencia = Id_Competencia;
            
        }

        public Competencias(int _Id_Competencia,string _Competencia)
        {
            this.Id_Competencia = _Id_Competencia;
            this.Competencia = _Competencia;

        }


        [Key]
        [Display(Name = "Id")]
        public int Id_Competencia { get; set; }
        [Key]
        [Display(Name = "Competencia")]
        public string Competencia { get; set; }
        //[Display(Name = "Descripción")]
        //public string Competencias_Desc { get; set; }
        //[Key]
        //public string Competencia { get; set; }
        [Display(Name = "Descripción")]
        public string Competencias_Desc { get; set; }

        
        [Display(Name = "Generico")]
        public int Generico { get; set; }
        [Display(Name = "Sociedad")]
        public string bukrs { get; set; }
        [Display(Name = "Grupo Sociedad")]
        public string gbukrs { get; set; }

    }
}
