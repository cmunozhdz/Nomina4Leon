using ASPNETCORERoleManagement.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models.Validaciones
{
    public class Valida1Attribute : ValidationAttribute
    {

 
        private string _gburk;
        private string _burk;
        private string _email;
        private readonly ApplicationDbContext _context;
  
        public Valida1Attribute(string gburk, string burk)
            : base ("El campo {0} ya existe en la base de datos")
        {
            _burk = burk;
            _gburk = gburk;
            


        }
     //   private Valida1Attribute(ApplicationDbContext context)
      //  {
       //    _context = context;
       // }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            { 
                if ((int)value != 0 )
                {
                    var mensajeDeError = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(mensajeDeError);
                }
            }
            //return base.IsValid(value, validationContext);  este es el original
            return ValidationResult.Success;
        }



    }
}
