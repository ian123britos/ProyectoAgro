using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAgro.Models;

namespace WebAgro.Controllers
{
    public class HomeController : Controller
    {
        private Sistema sis = Sistema.ObtenerInstancia();

        public IActionResult Index()
        {
            
            return RedirectToAction("TodasLasPublicacionesEnVenta", "Publicacion");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
