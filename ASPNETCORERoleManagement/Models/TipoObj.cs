﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASPNETCORERoleManagement.Data;

namespace ASPNETCORERoleManagement.Models
{

    public class TipoObj
    {
        [Key]
        [Display(Name = "Tipo Objetivo Id")]
        
        [Column(Order = 0)]
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Formato inválido")]
        public string TipoObjId { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee el Grupo de Compañía")]
        [Display(Name = "Grupo Compañia")]
        public string gbukrs { get; set; }



        [Required]
        [Display(Name = "Sociedad")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Teclee la Compañía")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public string bukrs { get; set; }


        
        [Required]
        [Display(Name = "Descripción")]
        [StringLength( 200, MinimumLength = 1, ErrorMessage = "Descripción, es obligatorio")]
        
        public string Descripcion { get; set; }

    }
    public class GetTipoObjDb
    {

        public TipoObj GetItem(string Id,ApplicationDbContext dbContext ) {
            if (Id==null)
            {
                return null;

            }
            TipoObj SelectItem = dbContext.TipoObj.Find(Id);
          
            return SelectItem;

        }

    }
    

     
}
