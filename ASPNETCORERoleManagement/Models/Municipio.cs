using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class Municipio
    {

        [Key]
        public int id { get; set; }


        [Display(Name = "clave")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Teclee clave de Municipio")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string mpio { get; set; }


        [Display(Name = "Municipio")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Teclee el Municipio")]
        public string descripcion { get; set; }
    
        public string region { get; set; }



    }
}
