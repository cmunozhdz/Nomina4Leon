using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASPNETCORERoleManagement.Models
{
    public class Tareaspersonal
    {
        [Key]
        [Display(Name = "Tarea Id")]
        
        public string TareaId { get; set; }
        [Key]
        [Display(Name = "No. Personal")]

        public string PERNR {get; set; }
        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }
        [Display(Name = "Fecha Registro")]
        public DateTime FRegistro { get; set; }

        [Display(Name = "% Avance")]

        public decimal PorcAvance { get; set; }

        
        [ForeignKey("TareaId")]
        public Tareas Tareas { get; set; }

    }
}
