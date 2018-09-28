using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class Genre
    {
        public string MunicGenre { get; set; }

        // Constructor.
        public Genre()
        {
        }

        public Genre(string a_MunicGenre)
        {
            MunicGenre = a_MunicGenre;
        }
    }
}
