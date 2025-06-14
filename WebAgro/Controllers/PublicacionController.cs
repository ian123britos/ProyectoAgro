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
        [HttpPost]
        public IActionResult FormularioTractorAltaDireccion(Direccion direccion)
        {
            try
            {
                sistema.AltaDireccion(direccion);
                return Redirect("FormularioTractorMaquinaria");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioTractorDireccion");
            }
        }


        public IActionResult FormularioTractorMaquinaria()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FormularioTractorAltaMaquinaria(Tractor tractor)
        {
            try
            {
                sistema.AltaMaquinaria(tractor);
                return Redirect("FormularioTractorPublicacionVenta");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioTractorMaquinaria");
            }
        }


        public IActionResult FormularioTractorPublicacionVenta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FormularioTractorAltaPublicacionVenta(Venta venta)
        {
            try
            {
                sistema.AltaPublicacion(venta);
                ViewBag.Exito = "✅ Maquinaria publicada con éxito";
                return View("FormularioTractorPublicacionVenta");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioTractorPublicacionVenta");
            }
        }

        public IActionResult TodasLasPublicacionesEnVenta()
        {
            List<Publicacion> lista = sistema.GetPublicacions();
            return View(lista);
        }
    }
}
