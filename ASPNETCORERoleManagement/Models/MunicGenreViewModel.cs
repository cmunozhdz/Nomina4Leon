using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORERoleManagement.Models
{
    public class MunicGenreViewModel
    {
        public List<Municipio> municipios;
        public SelectList genres;
        public string municGenre { get; set; }
    }
}
