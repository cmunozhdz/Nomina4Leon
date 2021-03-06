﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class IT16
    {
        public IT16()
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

        [Display(Name = "Clase de contrato")]
        [StringLength(2, ErrorMessage = "Máximo 2 caracteres")]
        public String Cttyp { get; set; }

        [Display(Name = "Período de prueba(cantidad)")]
        public int Prbzt { get; set; }

        [Display(Name = "Período de prueba(unidad)")]
        [StringLength(3, ErrorMessage = "Máximo 2 caracteres")]
        public String Prbeh { get; set; }


        public int PersonalId { get; set; }



    }
}
