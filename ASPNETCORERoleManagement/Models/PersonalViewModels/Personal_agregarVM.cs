using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models.PersonalViewModels
{
    public class Personal_agregarVM
    {
        public Personal_agregarVM()
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

        [Display(Name = "# de reg infotipo de misma clave")]
               public int Seqnr { get; set; }

        [Display(Name = "Inicio de Validez")]
        [DataType(DataType.Date)]
        public DateTime BegDa { get; set; }

        [Display(Name = "Fin de Validez")]
        [DataType(DataType.Date)]
        public DateTime EndDa { get; set; }
  
        [Display(Name = "Título")]
        [StringLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public String Title { get; set; }
        [Display(Name = "Nombre de Pila")]
        [StringLength(40)]
        public String Vorna { get; set; }

        [Display(Name = "Apellido")]
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public String Nachn { get; set; }

        [Display(Name = "Segundo Apellido")]
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public String Nach2 { get; set; }

 

        [Required]
        [Display(Name = "Movimiento")]
        public int IntMassgid { get; set; }
        [Required]
        [Display(Name = "Estatus")]
        public int Estatus { get; set; }
        

       
        [Required]
       
        [Display(Name = "Tipo Personal")]
        public int Tipo_pers { get; set; }

        [Required]
       
        [Display(Name = "Area de Personal")]
       
        public string Area_pers { get; set; }


        [Required]
        
        [Display(Name = "Division")]
        [StringLength(4)]
        public string Divi { get; set; }

        [Required]
       
        [Display(Name = "Subdivision")]
        [StringLength(4)]
        public string Subdivis { get; set; }

        [Required]
        [Display(Name = "Nomina")]
        
        public string Nomina { get; set; }

        [Required]
       
        [Display(Name = "Centro de Costos")]
        
        public string Cent_cost { get; set; }


        [Required]
        
        [Display(Name = "Unidad Organizativa")]
        
        public string Orgeh { get; set; }


        [Required]
       
        [Display(Name = "Posición")]
        
        public string Plans { get; set; }


        [Required]
       
        [Display(Name = "Función")]
        
        public string Stell { get; set; }

        


        [Display(Name = "Clase de contrato")]
       
        public String Cttyp { get; set; }

        [Display(Name = "Período de prueba(cant)")]
        
        public int Prbzt { get; set; }

        [Display(Name = "Período de prueba(unidad)")]
        
        public String Prbeh { get; set; }

           

        [Display(Name = "Curp")]
        [StringLength(14, ErrorMessage = "Máximo 14 caracteres")]
        public String Curp { get; set; }

        [Display(Name = "Clave de Sexo")]
      
        public String Gesch { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime GbDat { get; set; }

        [Display(Name = "País de nacimiento")]
        [StringLength(3, ErrorMessage = "3 Caracteres")]
        public String Gblnd { get; set; }

        [Display(Name = "Estado Federado")]
      
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
        [Display(Name = "INE")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Ine { get; set; }


        [Display(Name = "RFC")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Rfc { get; set; }

        [Display(Name = "Licencia")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Licencia { get; set; }
        [Display(Name = "ISSSTE")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Issste { get; set; }

        [Display(Name = "Afore")]
        [StringLength(30, ErrorMessage = "30 Caracteres")]
        public String Afore { get; set; }

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
        [StringLength(5)]
        [RegularExpression(@"^(?!00000)[0-9]{5,5}$", ErrorMessage = "Escriba un código postal valido")]
        public String Cod_post { get; set; }

        [Display(Name = "Estado")]
       
        public String Estado { get; set; }

        [Display(Name = "Municipio")]
       
        public String Munic { get; set; }

        [Display(Name = "Clave de País")]
        [StringLength(3)]
        public String Land1 { get; set; }

        [Display(Name = "No. de Teléfono")]
        public int Telnr { get; set; }

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



        [Display(Name = "Lun")]
     
        public Boolean Dia_1 { get; set; }

        [Display(Name = "Mar")]
   
        public Boolean Dia_2 { get; set; }

        [Display(Name = "Mié")]

        public Boolean Dia_3 { get; set; }

        [Display(Name = "Jue")]

        public Boolean Dia_4 { get; set; }

        [Display(Name = "Vie")]
   

        public Boolean Dia_5 { get; set; }

        [Display(Name = "Sáb")]

        public Boolean Dia_6 { get; set; }

        [Display(Name = "Dom")]
  
        public Boolean Dia_7 { get; set; }


        [Display(Name = "Sueldo Diario")]
        
       
        public Double Sueldo_dia { get; set; }

        [Display(Name = "Sueldo Mensual")]
        
       
        public Double Sueldo_mens { get; set; }

        [Display(Name = "Sueldo por Hora")]
       
       
        public Double Sdo_hora { get; set; }


        [Display(Name = "Tipo pago")]
        
        // cheque efectivo transferencia
      
        public string Tipo_pago { get; set; }

        [Display(Name = "Clave del Banco")]
   
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public int Banco { get; set; }

 

        [Display(Name = "Clave Pais")]
        [StringLength(3)]
        public string Pais { get; set; }

        [Display(Name = "Cuenta Banco")]
            public int Cuenta { get; set; }

        [Display(Name = "Sucursal")]
        [StringLength(30)]
        public string Plaza_cta { get; set; }

        [Display(Name = "Estado del Pais")]
        [StringLength(3)]
        public string Estado1 { get; set; }

        [Display(Name = "Clabe Interbancaria")]
        [StringLength(20)]
        public string Clabe_banco { get; set; }

      
    }
}
