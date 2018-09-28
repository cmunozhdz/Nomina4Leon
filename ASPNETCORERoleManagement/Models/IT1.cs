using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class IT1
    {

        public IT1()
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
       
        [Display(Name = "Division")]
        [StringLength(4)]
        public String  Divi { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [Display(Name = "Tipo Personal")]
        public int Tipo_pers { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [Display(Name = "Area de Personal")]
        [StringLength(2)]
        public string Area_pers { get; set; }


        [Required]
        
        [Display(Name = "Subdivision")]
        [StringLength(4)]
        public string Subdivis { get; set; }

        [Required]
        [Display(Name = "Nomina")]
        [StringLength(2)]
        public string Nomina { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [Display(Name = "Centro de Costos")]
        [StringLength(10)]
        public string Cent_cost { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [Display(Name = "Unidad Organizativa")]
        [StringLength(8)]
        public string Orgeh { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [Display(Name = "Posición")]
        [StringLength(8)]
        public string Plans { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [Display(Name = "Función")]
        [StringLength(8)]
        public string Stell { get; set; }

        public int PersonalId { get; set; }

    }
}
