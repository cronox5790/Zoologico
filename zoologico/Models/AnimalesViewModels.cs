using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zoologico.Models
{
    public class AnimalesViewModels
    {
        public int Imagen { get; set; }
        public IEnumerable<Clase> Clase { get; set; }
    }
}
