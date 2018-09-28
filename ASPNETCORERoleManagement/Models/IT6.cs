using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class IT6
    {

        public IT6()
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
        public DateTime BegDa { get; set; }

        [Display(Name = "Fin de Validez")]
        public DateTime EndDa { get; set; }

        [Display(Name = "# de un reg de infotipo para una misma clave")]
        public int Seqnr { get; set; }

        [Display(Name = "Fecha cambio")]
        public DateTime Aedtm { get; set; }

        [Display(Name = "Usuario cambio")]
        
        public String Uname { get; set; }

        [Display(Name = "Calle y número")]
        [StringLength(60)]
        public String Stras { get; set; }

        [Display(Name = "Colonia")]
        [StringLength(40)]
        public String Colonia { get; set; }

        [Display(Name = "Poblac")]
        [StringLength(40)]
        public String Poblac { get; set; }

        [Display(Name = "Código Postal")]
        [MaxLength(5)]
        [RegularExpression(@"^(?!00000)[0-9]{5,5}$", ErrorMessage = "Escriba un código postal valido")]
        public String Cod_post { get; set; }

        [Display(Name = "Estado")]
        [StringLength(3)]
        public String Estado { get; set; }

        [Display(Name = "Municipio")]
        [StringLength(4)]
        public String Munic { get; set; }

        [Display(Name = "Clave de País")]
        [StringLength(3)]
        public String Land1 { get; set; }

        [Display(Name = "No. de Teléfono")]
        [RegularExpression(@"^(\d{10,14})$", ErrorMessage = "Teclee no. de tel.")]
        public int Telnr { get; set; }

        public int PersonalId { get; set; }

    }
}
