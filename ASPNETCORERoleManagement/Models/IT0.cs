using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class IT0
    {

        public IT0()
        {
                
        }
        public int Id { get; set; }

        [Display(Name = "GpoCia")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee el Grupo de Compañía")]
        public string Gbukrs { get; set; }

        [Display(Name = "Cia")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee la Compañía")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string Bukrs { get; set; }


        [Required(ErrorMessage = "Número de Personal es requerido")]
        [Display(Name = "# de Personal")]
        public int Pernr { get; set; }

        [Display(Name = "Subtipo")]
        [StringLength(4, ErrorMessage = "Máximo 4 caracteres")]
        public string Subty { get; set; }

        [Display(Name = "Inicio de Validez")]
        [DataType(DataType.Date)]
        public DateTime BegDa { get; set; }

        [Display(Name = "Fin de Validez")]
        [DataType(DataType.Date)]
        public DateTime EndDa { get; set; }

        [Display(Name = "# de un reg de infotipo para una misma clave")]
        public int Seqnr { get; set; }

        [Display(Name = "Fecha cambio")]
        public DateTime Aedtm { get; set; }

        [Display(Name = "Usuario cambio")]
        public String Uname { get; set; }

        [Required]
        [Display(Name = "Movimiento")]
        [StringLength(2)]
        public string Massn { get; set; }

        [Required]
        [Display(Name = "Tipo de Movimiento")]
        [StringLength(2)]
        public string Massg { get; set; }

        [Required]
//        [RegularExpression(@"^[0-9]+[0-9]*$")]
 //       [RegularExpression(@"^([1 - 9]\d{0,3})?$")]
        [Display(Name = "Estatus")]
        public int Estatus { get; set; }


        public int PersonalId { get; set; }



    }
}
