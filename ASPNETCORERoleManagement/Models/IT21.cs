using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class IT21
    {
        public IT21()
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
        [StringLength(4, ErrorMessage = "Máximo 4 caracteres")]
        public string Subty { get; set; }

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

        [Display(Name = "Clase registro parentesco")]
        [StringLength(4)]
        [Required]
        public string Famsa { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required]
        public DateTime Fgbdt { get; set; }

        [Display(Name = "Pais de Nacimiento")]
        [StringLength(3)]
        [Required]
        public string Fgbld { get; set; }

        [Display(Name = "Nacionalidad")]
        [StringLength(3)]
        [Required]
        public string Fanat { get; set; }

        [Display(Name = "Clave de sexo")]
        [StringLength(1)]
        [Required]
        public string Fasex { get; set; }

        [Display(Name = "Nombre de pila")]
        [StringLength(40)]
        [Required]
        public string Favor { get; set; }
        [Display(Name = "Apellido Paterno")]
        [StringLength(40)]
        [Required]
        public string Fanam { get; set; }
        [Display(Name = "Apellido Materno")]
        [StringLength(40)]
        [Required]
        public string Fnac2 { get; set; }

        
        [Display(Name = "Lugar de Nacimiento")]
        [StringLength(40)]
        [Required]
        public string Fgbot { get; set; }

        [Display(Name = "Estado federado")]
        [StringLength(3)]
        [Required]
        public string Fgdep { get; set; }

        public int PersonalId { get; set; }

    }
}
