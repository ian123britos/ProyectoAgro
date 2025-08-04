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


        #region Formulario para dar de alta un tractor

        public IActionResult FormularioTractorCaracteristicas()
        {

            return View();
        }
        [HttpPost]
        public IActionResult FormularioTractorAltaCaracteristica(Caracteristica caracteristica)
        {
            try
            {
                sistema.AltaCaracteristica(caracteristica);
                //guardo el id en la session para que se me vayan guardando los campos de  caracteristicas que se van ingresando
                HttpContext.Session.SetInt32("IdCaracteristicaTractor", caracteristica.IdCaracteristica);

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
                //guardo el id en la session para que se me vayan guardando los campos de Direcciones que se van ingresando
                HttpContext.Session.SetInt32("IdDireccionTractor", direccion.IdDireccion);
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
                //Traigo los datos guardados que han sido ingresados en caracteristicas y direccion para que se guarden aqui
                int? caracteristicasCacheada = HttpContext.Session.GetInt32("IdCaracteristicaTractor");
                int? direccionCacheada = HttpContext.Session.GetInt32("IdDireccionTractor");
                if(caracteristicasCacheada == null || direccionCacheada == null)
                {
                    throw new Exception("Falto completar campos en las caracteristicas o en direccion");
                }

                //obtenemos las caracteristicas y las direcciones guardadas
                Caracteristica caracteristicaEnCach = sistema.ObtenerCaracteristicaPorId(caracteristicasCacheada.Value);
                Direccion direccionEnCach = sistema.ObtenerDireccionPorId(direccionCacheada.Value);

                //asigno los datos al tractor
                tractor.Caracteristica = caracteristicaEnCach;
                tractor.Direccion = direccionEnCach;

                sistema.AltaMaquinaria(tractor);
                //Guardo el id en la session para que se me vayan guardando los campos de maquinaria que se van ingresando
                HttpContext.Session.SetInt32("IdMaquinariaTractor", tractor.IdMaquinaria);

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
                int? tractorCacheado = HttpContext.Session.GetInt32("IdMaquinariaTractor");
                if(tractorCacheado == null)
                {
                    throw new Exception("Falta completar datos en maquinaria");
                }

                Maquinaria tractorEnCach = sistema.ObtenerMaquinariaPorId(tractorCacheado.Value);

                venta.UnaMaquina = tractorEnCach;
                venta.FechaPublicacionVenta = DateTime.Now;

                sistema.AltaPublicacion(venta);
                ViewBag.Exito = "✅ Maquinaria Tractor publicada con éxito";
                return View("FormularioTractorPublicacionVenta");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioTractorPublicacionVenta");
            }
        }
        #endregion


        #region Formulario para dar de alta una Sembradora
        public IActionResult FormularioSembradoraCaracteristicas()
        {

            return View();
        }

        [HttpPost]
        public IActionResult FormularioSembradoraAltaCaracteristicas(Caracteristica caracteristica)
        {
            try
            {

                sistema.AltaCaracteristica(caracteristica);
                HttpContext.Session.SetInt32("IdCaracteristicasSembradora", caracteristica.IdCaracteristica);

                return Redirect("FormularioSembradoraDireccion");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioSembradoraCaracteristicas");
            }
        }

        public IActionResult FormularioSembradoraDireccion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormularioSembradoraAltaDireccion(Direccion direccion)
        {
            try
            {

                sistema.AltaDireccion(direccion);
                HttpContext.Session.SetInt32("IdDireccionSembradora", direccion.IdDireccion);

                return Redirect("FormularioSembradoraMaquinaria");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioSembradoraDireccion");

            }
        }

        public IActionResult FormularioSembradoraMaquinaria()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormularioSembradoraAltaMaquinaria(Sembradora sembradora)
        {
            try
            {
                //traigo los datos para luego asignarlos a sembradora
                int? caracteristicaCacheada = HttpContext.Session.GetInt32("IdCaracteristicasSembradora");
                int? direccionCacheada = HttpContext.Session.GetInt32("IdDireccionSembradora");

                if (caracteristicaCacheada == null || direccionCacheada == null)
                {
                    throw new Exception("Falto completar campos en las caracteristicas o en direccion");

                }

                //guardo los datos que traje
                Caracteristica caracteristicaEnCach = sistema.ObtenerCaracteristicaPorId(caracteristicaCacheada.Value);
                Direccion direccionEnCach = sistema.ObtenerDireccionPorId(direccionCacheada.Value);

                //asigno los datos a la Sembradora
                sembradora.Caracteristica = caracteristicaEnCach;
                sembradora.Direccion = direccionEnCach;


                sistema.AltaMaquinaria(sembradora);
                //no olvidarme de hacer las session de las maquinarias como hice con las caracteristicas y direcciones
                HttpContext.Session.SetInt32("IdMaquinariaSembradora", sembradora.IdMaquinaria);
                return Redirect("FormularioSembradoraPublicacionVenta");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioSembradoraMaquinaria");
            }

        }

        public IActionResult FormularioSembradoraPublicacionVenta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FormularioSembradoraAltaPublicacionVenta(Venta venta)
        {
            try
            {
                int? sembradoraCacheada = HttpContext.Session.GetInt32("IdMaquinariaSembradora");
                if (sembradoraCacheada == null)
                {
                    throw new Exception("Falto completar campos en maquinaria sembradora");
                }

                Maquinaria sembradoraEnCach = sistema.ObtenerMaquinariaPorId(sembradoraCacheada.Value);
                venta.UnaMaquina = sembradoraEnCach;
                venta.FechaPublicacionVenta = DateTime.Now;


                sistema.AltaPublicacion(venta);
                ViewBag.Exito = "✅ Maquinaria Sembradora publicada con éxito";
                return View("FormularioSembradoraPublicacionVenta");

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioSembradoraPublicacionVenta");
            }
        }
        #endregion

        #region Formulario para dar de alta una Fertilizadora
        public IActionResult FormularioFertilizadoraCaracteristicas()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormularioFertilizadoraAltaCaracteristicas(Caracteristica caracteristica)
        {
            try
            {
                sistema.AltaCaracteristica(caracteristica);
                HttpContext.Session.SetInt32("IdCaracteristicaFertilizadora", caracteristica.IdCaracteristica);
                return Redirect("FormularioFertilizadoraDireccion");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioFertilizadoraCaracteristicas");
            }
        }
        #endregion


        #region Filtrados:
        public IActionResult TodasLasPublicacionesEnVenta()
        {
            List<Publicacion> lista = sistema.GetPublicacions();
            return View(lista);
        }

        [HttpPost]
        public IActionResult FiltradoPorMarcaDeMaquinaria(string marca)
        {
            List<Publicacion> VerPorMarca = sistema.ObtenerMaquinariaPorMarca(marca);
            return View(VerPorMarca);
        }

        #endregion
    }
}
