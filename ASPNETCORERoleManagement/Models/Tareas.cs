using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASPNETCORERoleManagement.Models
{
    public class Tareas
    {
        private DateTime FechaActual=DateTime.Now ;
        

        [Key]
        [Display(Name = "Id Tarea")]
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Formato inválido")]
        public string TareaId { get; set; }

 
        [Display(Name = "Descripción")]
        [Required]
        [MaxLength(2000)]

        public string TareasDesc { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha Registro")]
        


        public DateTime TareasFechaRegistro {

            get {
                
                return FechaActual;


            }
            set {
                FechaActual = value;

             
                

            }
        }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha Fin Deseado")]
        [DataType(DataType.Date)]
        public DateTime? TareasFechaFinDeseado { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha Fin Real")]
        [DataType(DataType.Date)]
        public DateTime? TareasFechaFinReal { get; set; }


        [Display(Name = "Id Objetivo")]
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Formato inválido")]

        public string IdObjetivo { get; set; }

        [ForeignKey("IdObjetivo")]
        public Objetivo Objetivo { get; set; }

    }
}
