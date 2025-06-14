using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebAgro.Controllers
{
    public class PublicacionController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        public IActionResult SeleccionarTipoMaquinaria()
        {
            return View();
        }

        public IActionResult FormularioTractorCaracteristicas()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult FormularioTractorAltaCaracteristicas(Caracteristica caracteristica)
        {


            try
            {
                sistema.AltaCaracteristica(caracteristica);
                return Redirect("FormularioTractorDireccion");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioTractorCaracteristicas");
            }
            
        }

        public IActionResult FormularioTractorDireccion()
        {
            return View();
        }
    }
}
