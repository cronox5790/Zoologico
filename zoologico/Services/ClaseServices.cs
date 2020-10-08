using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zoologico.Models;

namespace zoologico.Services
{
    public class ClaseServices

    {
        public List<Clase> Clases { get; set; }
        public ClaseServices()
        {
            using (animalesContext context = new animalesContext())
            {
                Clases = context.Clase.OrderBy(X => X.Nombre).ToList();
            }
        }
    }
}