using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillanzicosProyectoJulio.Models;

namespace VillanzicosProyectoJulio.Controllers
{
    public class HomeController : Controller
    {
        //[Route("Inicio")]
        public IActionResult Index()
        {
            villancicosContext context = new();
            var villancicos = context.Villancicos.OrderBy(x => x.Nombre);
            return View(villancicos);
        }
        [Route("villancico/{nombre}/video")]
        public IActionResult Villanzico(string nombre)
        {

            nombre = nombre.Replace("-", " ");

            villancicosContext context = new();
        
            var villancicos = context.Villancicos.FirstOrDefault(x => x.Nombre == nombre);
            if (villancicos!=null)
            {
                return View(villancicos);

              
            }

         else
            {
                return RedirectToAction("Index");
            }
        }
        [Route("villancico/{nombre}/letra")]
        public IActionResult VillancicoLetra(string nombre)
        {
            nombre = nombre.Replace("-", " ");

            villancicosContext context = new();
            var villancicos = context.Villancicos.FirstOrDefault(x => x.Nombre == nombre);
            if (villancicos != null)
            {
                return View(villancicos);


            }
         
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
