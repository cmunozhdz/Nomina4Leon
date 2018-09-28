using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class IT9
    {
        public IT9()
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

        [Display(Name = "Clave del Banco")]
        [Range(0, 99999)]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public int Banco { get; set; }

        [Display(Name = "Tipo pago")]
        [RegularExpression(@"^[CET]$")]
        [StringLength(1)]
        public string Tipo_pago { get; set; }

        [Display(Name = "Clave Pais")]
        [StringLength(3)]
        public string Pais { get; set; }

        [Display(Name = "Cuenta Banco")]
        [MinLength(15)]
        public int Cuenta { get; set; }

        [Display(Name = "Sucursal")]
        [StringLength(30)]
        public string Plaza_cta { get; set; }

        [Display(Name = "Estado del Pais")]
        [StringLength(3)]
        public string Estado { get; set; }

        [Display(Name = "Clabe Interbancaria")]
        [StringLength(20)]
        public string Clabe_banco { get; set; }

        public int PersonalId { get; set; }

    }
}
