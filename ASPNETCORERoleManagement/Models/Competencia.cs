using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;


namespace ASPNETCORERoleManagement.Models
{
    public class Competencia
    {
        [Display(Name = "Id competencia")]
        public int Id { get; set; }
        //public string Competencia { get; set; }
        //[Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Generico")]
        public string Generico { get; set; }
        [Display(Name = "Sociedad")]
        public string Bukrs { get; set; }
        [Display(Name = "Grupo Sociedad")]
        public string Gbukrs { get; set; }

    }

}
