using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using zoologico.Models;

namespace zoologico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            animalesContext context = new animalesContext();
            AnimalesViewModels animvm = new AnimalesViewModels();
            animvm.Clase = context.Clase.OrderBy(x => x.Nombre.ToUpper());
            Random ra = new Random();
            animvm.Imagen = ra.Next(1, 6);
            return View(animvm);
        }
        [Route("{id}")]

        public IActionResult Clases(String id)
        {
            var nom = id.Replace(" ", "-").ToLower();
            animalesContext context = new animalesContext();
            var cate = context.Clase.Include(x => x.Especies)
                .ThenInclude(x => x.IdClaseNavigation).OrderBy(x => x.Nombre).
                FirstOrDefault(x => x.Nombre.ToLower() == nom);
            if (cate==null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(cate);
            }
        }
    }
}

