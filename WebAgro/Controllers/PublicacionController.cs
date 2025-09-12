using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Dominio.EntidadesNegocio;
using CasosDeUsos.InterfacesCasosDeUso.ICaracteristicaCasoDeUso;
using CasosDeUsos.DTOs.CaracteristicaDTOs;
using ExcepcionesPropias;
using CasosDeUsos.InterfacesCasosDeUso.IDireccionCasoDeUso;
using CasosDeUsos.DTOs.DireccionDTO;
using CasosDeUsos.InterfacesCasosDeUso.IMaquinariaCasosDeUso;
using CasosDeUsos.DTOs.MaquinariaDTO;


namespace WebAgro.Controllers
{
    public class PublicacionController : Controller
    {
        public ICUAltaCaracteristica CUAltaCaracteristica { get; set; }
        public ICUAltaDireccion CUAltaDireccion { get; set; }
        public ICUAltaMaquinariaTractor CUAltaMaquinariaTractor { get; set; }
        public ICUAltaMaquinariaSembradora CUAltaMaquinariaSembradora { get; set; }
        public ICUAltaMaquinariaFertilizadora CUAltaMaquinariaFertilizadora { get; set; }

        private readonly IWebHostEnvironment _webHostEnvironment;

        // Constructor con inyección de dependencias
        public PublicacionController(IWebHostEnvironment webHostEnvironment,ICUAltaCaracteristica cUAltaCaracteristica, ICUAltaDireccion cUAltaDireccion, ICUAltaMaquinariaTractor cUAltaMaquinariaTractor, ICUAltaMaquinariaSembradora cUAltaMaquinariaSembradora, ICUAltaMaquinariaFertilizadora cUAltaMaquinariaFertilizadora)
        {
            CUAltaCaracteristica = cUAltaCaracteristica;
            _webHostEnvironment = webHostEnvironment;
            CUAltaDireccion = cUAltaDireccion;
            CUAltaMaquinariaTractor = cUAltaMaquinariaTractor;
            CUAltaMaquinariaSembradora = cUAltaMaquinariaSembradora;
            CUAltaMaquinariaFertilizadora = cUAltaMaquinariaFertilizadora;
        }

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
        [ValidateAntiForgeryToken]
        public IActionResult FormularioTractorAltaCaracteristica(CaracteristicaDTO caracteristicaDTO)
        {
            try
            {

               //Verifica si el modelo(cliente en tu caso) pasó todas las validaciones definidas.
               if(ModelState.IsValid)
                {
                    CUAltaCaracteristica.Ejecutar(caracteristicaDTO);
                    return Redirect("FormularioTractorDireccion");
                }

            }
            catch (CaracteristicaException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("FormularioTractorCaracteristicas");

        }


        public IActionResult FormularioTractorDireccion()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioTractorAltaDireccion(DireccionDTO direccionDTO)
        {
            try
            {

                ////guardo el id en la session para que se me vayan guardando los campos de Direcciones que se van ingresando
                //HttpContext.Session.SetInt32("IdDireccionTractor", direccion.IdDireccion);
                if (ModelState.IsValid)
                {
                    CUAltaDireccion.Ejecutar(direccionDTO);
                    return Redirect("FormularioTractorMaquinaria");

                }
            }
            catch (DireccionException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("FormularioTractorDireccion");
          
        }
        public IActionResult FormularioTractorMaquinaria()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioTractorAltaMaquinaria(TractorDTO tractorDTO)
        {
            try
            {
                //Traigo los datos guardados que han sido ingresados en caracteristicas y direccion para que se guarden aqui
                //int? caracteristicasCacheada = HttpContext.Session.GetInt32("IdCaracteristicaTractor");
                //int? direccionCacheada = HttpContext.Session.GetInt32("IdDireccionTractor");
                //if(caracteristicasCacheada == null || direccionCacheada == null)
                //{
                //    throw new Exception("Falto completar campos en las caracteristicas o en direccion");
                //}

                ////obtenemos las caracteristicas y las direcciones guardadas
                //Caracteristica caracteristicaEnCach = sistema.ObtenerCaracteristicaPorId(caracteristicasCacheada.Value);
                //Direccion direccionEnCach = sistema.ObtenerDireccionPorId(direccionCacheada.Value);

                //asigno los datos al tractor
                //tractor.Caracteristica = caracteristicaEnCach;
                //tractor.Direccion = direccionEnCach;

                // ✅ Asignar ID manualmente
                //tractor.IdMaquinaria = Maquinaria.UltimoIdMaquinaria++;

                //sistema.AltaMaquinaria(tractor);
                //Guardo el id en la session para que se me vayan guardando los campos de maquinaria que se van ingresando
                //HttpContext.Session.SetInt32("IdMaquinariaTractor", tractor.IdMaquinaria);

                if (ModelState.IsValid)
                {
                    CUAltaMaquinariaTractor.Ejecutar(tractorDTO);
                    return Redirect("FormularioTractorPublicacionVenta");

                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("FormularioTractorMaquinaria");

        }


        public IActionResult FormularioTractorPublicacionVenta()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormularioTractorAltaPublicacionVenta(Venta venta, IFormFile fotoArchivo)
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

                // Guardar la imagen si viene archivo
                if (fotoArchivo != null && fotoArchivo.Length > 0)
                {                                 //para chatgpt: _webHostEnvironment esto me aparece en rojo
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fotoArchivo.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await fotoArchivo.CopyToAsync(fileStream);// y todo esto tambien me aparece en rojo
                    }

                    venta.Foto = "/uploads/" + uniqueFileName;
                }
                else
                {
                    // Opcional: poner una imagen por defecto si no se subió ninguna foto
                    venta.Foto = "/images/default-maquinaria.jpg";
                }

                //venta.IdPublicacion = Publicacion.UltimoIdPublicacion++;

                sistema.AltaPublicacion(venta);
                ViewBag.Exito = "✅ Maquinaria Tractor publicada con éxito";
                return View("FormularioTractorPublicacionVenta");
                //return RedirectToAction("ObtenerMaquinariaPorId", new { id = venta.IdPublicacion });

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
        [ValidateAntiForgeryToken]
        public IActionResult FormularioSembradoraAltaCaracteristicas(CaracteristicaDTO caracteristicaDTO)
        {
            try
            {

                //Verifica si el modelo(caracteristica en tu caso) pasó todas las validaciones definidas.
                if (ModelState.IsValid)
                {
                    CUAltaCaracteristica.Ejecutar(caracteristicaDTO);
                    return Redirect("FormularioSembradoraDireccion");
                }

            }
            catch (CaracteristicaException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("FormularioSembradoraCaracteristicas");

        }

        public IActionResult FormularioSembradoraDireccion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioSembradoraAltaDireccion(DireccionDTO direccionDTO)
        {
            try
            {
                //HttpContext.Session.SetInt32("IdDireccionSembradora", direccion.IdDireccion);
                if (ModelState.IsValid)
                {
                    CUAltaDireccion.Ejecutar(direccionDTO);
                    return Redirect("FormularioSembradoraMaquinaria");
                }
            }
            catch (DireccionException ex)
            {
                TempData["Error"] = ex.Message;

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;


            }
            return RedirectToAction("FormularioSembradoraDireccion");

        }

        public IActionResult FormularioSembradoraMaquinaria()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioSembradoraAltaMaquinaria(SembradoraDTO sembradoraDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CUAltaMaquinariaSembradora.Ejecutar(sembradoraDTO);
                    return Redirect("FormularioSembradoraPublicacionVenta");
                }
            }
            catch (MaquinariaSembradoraException ex)
            {
                TempData["Error"] = ex.Message;
               
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

            }
            return RedirectToAction("FormularioSembradoraMaquinaria");


        }

        public IActionResult FormularioSembradoraPublicacionVenta()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FormularioSembradoraAltaPublicacionVenta(Venta venta, IFormFile fotoArchivo)//parametro para guardar fotos
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


                // Guardar la imagen si viene archivo
                if (fotoArchivo != null && fotoArchivo.Length > 0)
                {                                 //para chatgpt: _webHostEnvironment esto me aparece en rojo
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fotoArchivo.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await fotoArchivo.CopyToAsync(fileStream);// y todo esto tambien me aparece en rojo
                    }

                    venta.Foto = "/uploads/" + uniqueFileName;
                }
                else
                {
                    // Opcional: poner una imagen por defecto si no se subió ninguna foto
                    venta.Foto = "/images/default-maquinaria.jpg";
                }

                //venta.IdPublicacion = Publicacion.UltimoIdPublicacion++;
                sistema.AltaPublicacion(venta);

                ViewBag.Exito = "✅ Maquinaria Sembradora publicada con éxito";
                return View("FormularioSembradoraPublicacionVenta");
                //return RedirectToAction("ObtenerMaquinariaPorId", new { id = venta.IdPublicacion });


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
        [ValidateAntiForgeryToken]
        public IActionResult FormularioFertilizadoraAltaCaracteristicas(CaracteristicaDTO caracteristicaDTO)
        {
            try
            {

                //Verifica si el modelo(cliente en tu caso) pasó todas las validaciones definidas.
                if (ModelState.IsValid)
                {
                    CUAltaCaracteristica.Ejecutar(caracteristicaDTO);
                    return Redirect("FormularioFertilizadoraDireccion");
                }

            }
            catch (CaracteristicaException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("FormularioFertilizadoraCaracteristicas");

        }

        public IActionResult FormularioFertilizadoraDireccion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioFertilizadoraAltaDireccion(DireccionDTO direccionDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //HttpContext.Session.SetInt32("IdDireccionFertilizadora", direccion.IdDireccion);
                    CUAltaDireccion.Ejecutar(direccionDTO);
                    return Redirect("FormularioFertilizadoraMaquinaria");
                }
            }
            catch (DireccionException ex)
            {
                TempData["Error"] = ex.Message;

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("FormularioFertilizadoraDireccion");


        }

        public IActionResult FormularioFertilizadoraMaquinaria()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioFertilizadoraAltaMaquinaria(FertilizadoraDTO fertilizadoraDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CUAltaMaquinariaFertilizadora.Ejecutar(fertilizadoraDTO);
                    return Redirect("FormularioFertilizadoraPublicacionVenta");
                }
            }
            catch (MaquinariaFertilizadoraException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("FormularioFertilizadoraMaquinaria");


        }

        public IActionResult FormularioFertilizadoraPublicacionVenta()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FormularioFertilizadoraAltaPublicacionVenta(Venta venta, IFormFile fotoArchivo)//parametro para guardar fotos
        {
            try
            {
                int? FertilizadoraCacheada = HttpContext.Session.GetInt32("IdMaquinariaFertilizadoraa");
                if (FertilizadoraCacheada == null)
                {
                    throw new Exception("Falto completar campos en maquinaria sembradora");
                }

                Maquinaria FertilizadoraEnCach = sistema.ObtenerMaquinariaPorId(FertilizadoraCacheada.Value);
                venta.UnaMaquina = FertilizadoraEnCach;
                venta.FechaPublicacionVenta = DateTime.Now;


                // Guardar la imagen si viene archivo
                if (fotoArchivo != null && fotoArchivo.Length > 0)
                {                                 //para chatgpt: _webHostEnvironment esto me aparece en rojo
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fotoArchivo.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await fotoArchivo.CopyToAsync(fileStream);// y todo esto tambien me aparece en rojo
                    }

                    venta.Foto = "/uploads/" + uniqueFileName;
                }
                else
                {
                    // Opcional: poner una imagen por defecto si no se subió ninguna foto
                    venta.Foto = "/images/default-maquinaria.jpg";
                }

                //venta.IdPublicacion = Publicacion.UltimoIdPublicacion++;
                sistema.AltaPublicacion(venta);

                ViewBag.Exito = "✅ Maquinaria Fertilizadora publicada con éxito";
                return View("FormularioFertilizadoraPublicacionVenta");
                //return RedirectToAction("ObtenerMaquinariaPorId", new { id = venta.IdPublicacion });


            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioFertilizadoraPublicacionVenta");
            }
        }
        #endregion


        #region Filtrados:
        public IActionResult TodasLasPublicacionesEnVenta()
        {
            List<Venta> lista = sistema.ObtenerTodasLasPublicacionesVenta();
            return View(lista);
        }

        [HttpPost]
        public IActionResult FiltradoPorMarcaDeMaquinaria(string marca)
        {
            try
            {
                List<Publicacion> VerPorMarca = sistema.ObtenerMaquinariaPorMarca(marca);
                return View(VerPorMarca);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("TodasLasPublicacionesEnVenta");
            }
        }


        //Filtrados por Maquinaria:
        public IActionResult FiltrarPorTipoTractor()
        {
            List<Venta> FiltradoPorTractoresEnVenta = sistema.ObtenerListaDeTractoresEnVenta();
            return View(FiltradoPorTractoresEnVenta);

        }

        public IActionResult FiltrarPorTipoSembradora()
        {
            List<Venta> FiltradoPorSembradorasEnVenta = sistema.ObtenerListaDeSembradorasEnVenta();

            return View(FiltradoPorSembradorasEnVenta);
        }

        public IActionResult FiltrarPorTipoFertilizadora()
        {
            List<Venta> FiltradoPorFertilizadorasEnVenta = sistema.ObtenerListaDeFertilizadorasEnVenta();

            return View(FiltradoPorFertilizadorasEnVenta);
        }
        #endregion


        //public IActionResult ObtenerMaquinariaPorId(int id)
        //{
        //    Publicacion MaquinarEnVentaSuDetalle = sistema.ObtenerPublicacionPorId(id);
        //    return View(MaquinarEnVentaSuDetalle);
        //}
        public IActionResult ObtenerMaquinariaPorId(int id)
        {
            Publicacion publicacion = sistema.ObtenerPublicacionPorMaquinariaId(id);
            return View(publicacion);
        }
        //PUDE VER DETALLE DE UNA MAQUINARIA QUE YO PUBLIQUE, ES UN BUEN AVANCE SOLO TUVE QUE IR AL ID DE LA MAQUINARIA QUE ESTA PUBLICADA, Y NO AL ID DE LA PUBLICACION

    }
}
