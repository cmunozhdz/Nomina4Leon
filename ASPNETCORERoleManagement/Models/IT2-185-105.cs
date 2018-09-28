using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class IT2_185_105
    {
        public IT2_185_105()
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


        [Display(Name = "Título")]
        [StringLength(15, ErrorMessage = "Máximo 2 caracteres")]
        public String Title { get; set; }
        [Display(Name = "Segundo Título")]
        [StringLength(15, ErrorMessage = "Máximo 2 caracteres")]
        public String Titl2 { get; set; }


    
        [Display(Name = "Curp")]
        [StringLength(14, ErrorMessage = "Máximo 14 caracteres")]
        public String Curp { get; set; }

        [Display(Name = "Clave de Sexo")]
        [StringLength(1, ErrorMessage = "1-Masculino,2-Femenino, 3-Indefinido")]
        public String Gesch { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime GbDat { get; set; }

        [Display(Name = "País de nacimiento")]
        [StringLength(3, ErrorMessage = "3 Caracteres")]
        public String Gblnd { get; set; }

        [Display(Name = "Estado Federado")]
        [StringLength(3, ErrorMessage = "3 Caracteres")]
        public String Gbdep { get; set; }

        [Display(Name = "Lugar de nacimiento")]
        [StringLength(40, ErrorMessage = "40 Caracteres")]
        public String Gbort { get; set; }

        [Display(Name = "Nacionalidad")]
        [StringLength(3, ErrorMessage = "3 Caracteres")]
        public String Natio { get; set; }

        [Display(Name = "Clase de Comunicación")]
        [StringLength(4, ErrorMessage = "1-Correo Empresa, 2-Correo Personal, 3 Celular, 4 - Usuario")]
        public String Usrty1 { get; set; }

        [Display(Name = "Comunicación")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Usrid1 { get; set; }

        [Display(Name = "Clase de Comunicación")]
        [StringLength(4, ErrorMessage = "1-Correo Empresa, 2-Correo Personal, 3 Celular, 4 - Usuario")]
        public String Usrty2 { get; set; }

        [Display(Name = "Comunicación")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Usrid2 { get; set; }

        [Display(Name = "Clase de Comunicación")]
        [StringLength(4, ErrorMessage = "1-Correo Empresa, 2-Correo Personal, 3 Celular, 4 - Usuario")]
        public String Usrty3 { get; set; }

        [Display(Name = "Comunicación")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Usrid3 { get; set; }

        [Display(Name = "Clase de Comunicación")]
        [StringLength(4, ErrorMessage = "1-Correo Empresa, 2-Correo Personal, 3 Celular, 4 - Usuario")]
        public String Usrty4 { get; set; }

        [Display(Name = "Comunicación")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Usrid4 { get; set; }

        [Display(Name = "INE")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Ine { get; set; }


        [Display(Name = "RFC")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Rfc { get; set; }

        [Display(Name = "Licencia")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Licencia { get; set; }

        [Display(Name = "Cartilla")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Cartilla { get; set; }

        [Display(Name = "Pasaporte")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Pasaporte { get; set; }

        [Display(Name = "FM2")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Fm2 { get; set; }

        [Display(Name = "FM3")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Fm3 { get; set; }
        [Display(Name = "ISSSTE")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Issste { get; set; }

        [Display(Name = "Afore")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Afore { get; set; }

        public int PersonalId { get; set; }


    }
}
