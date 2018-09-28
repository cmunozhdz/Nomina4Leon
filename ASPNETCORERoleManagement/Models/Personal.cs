using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class Personal
    {
        public Personal()
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
        [DataType(DataType.Date)]
        public DateTime BegDa { get; set; }

        [Display(Name = "Fin de Validez")]
        [DataType(DataType.Date)]
        public DateTime EndDa { get; set; }

        [Display(Name = "# de un reg de infotipo para una misma clave")]
        [MaxLength(3)]
        public int Seqnr { get; set; }

        [Display(Name = "Fecha cambio")]
        public DateTime Aedtm { get; set; }

        [Display(Name = "Usuario cambio")]
        [StringLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public String Uname { get; set; }

          


        [Display(Name = "Nombre de Pila")]
        [MaxLength(40)]
        public String Vorna { get; set; }

        [Display(Name = "Apellido")]
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public String Nachn { get; set; }

        [Display(Name = "Segundo Apellido")]
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public String Nach2 { get; set; }

        [Display(Name = "Nombre Completo")]
        [StringLength(80, ErrorMessage = "Máximo 40 caracteres")]
        public String Cname
        {
            get;set;
        }

        public List<IT0> IT0s { get; set; }
        public List<IT1> IT1s{ get; set; }
        public List<IT16> IT16s { get; set; }

        public List<IT21> IT21s { get; set; }
        public List<IT2_185_105> IT2_185_105s { get; set; }
        public List<IT369> IT369x { get; set; }

        public List<IT41> IT41s { get; set; }
        public List<IT6> IT6s { get; set; }
        public List<IT7> IT7s { get; set; }
        public List<IT8> IT8s { get; set; }
        public List<IT9> IT9s { get; set; }


    }
}
