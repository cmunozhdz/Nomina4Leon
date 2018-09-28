using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class PersonalInfotipos
    {
        public PersonalInfotipos()
        {

        }

        public Personal Personal { get; set; }

        [Display(Name = "Movimiento / Tipo de Movimiento")]
        public int IdMassg { get; set; }
        public IT0 IT0 { get; set; }

         public IT1 IT1 { get; set; }
        public IT16 IT16 { get; set; }

        public IT21 IT21 { get; set; }
        public IT2_185_105 IT2_185_105 { get; set; }
        public IT369 IT369 { get; set; }

        public IT41 IT41 { get; set; }
        public IT6 IT6 { get; set; }
        public IT7 IT7 { get; set; }
        public IT8 IT8 { get; set; }
        public IT9 IT9 { get; set; }


    }
}
