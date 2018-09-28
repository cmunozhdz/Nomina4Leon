using ASPNETCORERoleManagement.Models.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class Cat1
    {


        public Cat1()
        {

        }
        public Cat1(string gbukrs)
        {
            Gbukrs = gbukrs;
        }
        public int Id { get; set; }

        [Display(Name = "GpoCia")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee el Grupo de Compañía")]
        public string Gbukrs { get; set; }
        [Display(Name = "Cia")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee la Compañía")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string Bukrs { get; set; }

        [Required(ErrorMessage = "Email es un campo requerido.")]
        [EmailAddress(ErrorMessage = "Teclee un formato valido de Email")]
        [Display(Name = "Email ")]

        public string Correo_resp { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Descripción larga ")]
        [Required]
        public string Nombre_largo { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Teclee la descripción ")]
        [Display(Name = "Descripción ")]
        [Required]
        public string Nombre { get; set; }
        [StringLength(15, MinimumLength = 3)]
        [Required]
        [Display(Name = "Pais ")]
        public string Pais { get; set; }
        [StringLength(20, MinimumLength = 10)]
        [Required]
        [Display(Name = "RFC ")]
        public string Rfc { get; set; }
        [StringLength(20)]
        [Display(Name = "Oficina Hacienda ")]
        public string Of_schp { get; set; }
        [Display(Name = "Calle Número ")]
        [StringLength(30)]

        public string Calle_num { get; set; }
        [Display(Name = "Núm Edificio")]
        [StringLength(15)]
        public string Num_edif { get; set; }
        [Display(Name = "Colonia")]
        [StringLength(40)]

        public string Colonia { get; set; }
        [Display(Name = "Población")]
        [StringLength(40)]
        public string Poblac { get; set; }
        [Display(Name = "Código Postal")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Debe teclear un número de 5 caracteres")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]

        public string Cod_post { get; set; }
        [Display(Name = "Estado")]
        [StringLength(3)]
        public string Estado { get; set; }
        [Display(Name = "Municipio")]
        [StringLength(4)]
        public string Munic { get; set; }
        [Display(Name = "Teléfono")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Teclee Teléfono a 10 digitos")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string Telefono { get; set; }
        [Display(Name = "Celular")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Teclee Celular a 10 digitos")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string Tel_cel_respo { get; set; }
        [Display(Name = "Skype")]
        [StringLength(20)]
        public string Skype_resp { get; set; }
        [Display(Name = "Nombre Responsable")]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "Teclee el nombre del responsable")]
        [Required]
        public string Nombre_resp { get; set; }






    }
}
