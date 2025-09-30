using Dominio.EntidadesNegocio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAgro.Models;

namespace WebAgro.Controllers
{
    public class HomeController : Controller
    {
       

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
