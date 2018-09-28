using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class IT7
    {
        public IT7()
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
        [DataType(DataType.Date)]
        public DateTime Aedtm { get; set; }

        [Display(Name = "Usuario cambio")]
       

        public String Uname { get; set; }

        [Display(Name = "Horas c punto decimal")]
        public Double Hrs_Trab { get; set; }

        [Display(Name = "Hora entrada Teórica")]
        [DataType(DataType.Time)]
        public TimeSpan Hr_Entrada { get; set; }

        [Display(Name = "Hora salida Teórica")]
        [DataType(DataType.Time)]
        public TimeSpan Hr_Salida { get; set; }

        [Display(Name = "Hora entrada1 Teórica")]
        [DataType(DataType.Time)]
        public TimeSpan Hr_Pausa1 { get; set; }

        [Display(Name = "Hora salida1 Teórica")]
        [DataType(DataType.Time)]
        public TimeSpan Hr_Pausa2 { get; set; }


        [Display(Name = "Lunes")]
        [MaxLength(1)]
        public int Dia_1 { get; set; }

        [Display(Name = "Martes")]
        [MaxLength(1)]
        public int Dia_2 { get; set; }

        [Display(Name = "Miércoles")]
        [MaxLength(1)]
        public int Dia_3 { get; set; }

        [Display(Name = "Jueves")]
        [MaxLength(1)]
        public int Dia_4 { get; set; }

        [Display(Name = "Viernes")]
        [MaxLength(1)]

        public int Dia_5 { get; set; }

        [Display(Name = "Sábado")]
        [MaxLength(1)]
        public int Dia_6 { get; set; }

        [Display(Name = "Domingo")]
        [MaxLength(1)]
        public int Dia_7 { get; set; }

        public int PersonalId { get; set; }

    }
}
