using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class IT369
    {
        public IT369()
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
        [MaxLength(8)]
        public int Pernr { get; set; }

        [Display(Name = "Subtipo")]
        [StringLength(4,ErrorMessage ="Máximo 4 caracteres")]
        public string  Subty { get; set; }

        [Display(Name = "Inicio de Validez")]
        public DateTime BegDa { get; set; }

        [Display(Name = "Fin de Validez")]
        public DateTime EndDa { get; set; }

        [Display(Name = "# de un reg de infotipo para una misma clave")]
        [MaxLength(3)]
        public int Seqnr { get; set; }

        [Display(Name = "Fecha cambio")]
        public DateTime Aedtm { get; set; }

        [Display(Name = "Usuario cambio")]
        

        public String Uname { get; set; }

        [Display(Name = "Relación del empleado con IMSS")]
        [StringLength(1)]
        [Required]
        public string Rimss { get; set; }

        [Display(Name = "Número de afiliación al IMSS")]
        [StringLength(11)]
        [Required]
        public string Nimss { get; set; }

        [Display(Name = "Indicador tipo de jornada reducida (Días/Horas)")]
        [StringLength(1)]
        [Required]
        public string Ijred { get; set; }

        public int PersonalId { get; set; }
    }
}
