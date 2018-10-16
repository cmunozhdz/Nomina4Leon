using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASPNETCORERoleManagement.Models
{
    public class Objetivo
    {
        [Key]
        [Display(Name = "Id Objetivo")]
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Formato inválido")]
        public string IdObjetivo { get; set; }

        [Display(Name = "Descripción")]
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Formato inválido")]
        public string Descripcion { get; set; }


        [Display(Name = "Inicio")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Inicio { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fin")]
        [DataType(DataType.Date)]

        [Required]
        public DateTime? Fin { get; set; }


        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Formato inválido")]
        public String TipoObjId { get; set; }

        [ForeignKey("TipoObjId")]
        public TipoObj TipoObj { get; set; }

        //public virtual TipoObj TipoObj { get; set; }

    }
}
