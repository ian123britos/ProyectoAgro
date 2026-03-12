using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Dominio.EntidadesNegocio;
using CasosDeUsos.InterfacesCasosDeUso.ICaracteristicaCasoDeUso;
using CasosDeUsos.DTOs.CaracteristicaDTO;
using CasosDeUsos.InterfacesCasosDeUso.IDireccionCasoDeUso;
using CasosDeUsos.DTOs.DireccionDTO;
using CasosDeUsos.InterfacesCasosDeUso.IMaquinariaCasosDeUso;
using CasosDeUsos.DTOs.MaquinariaDTO;
//using AspNetCore;
using CasosDeUsos.InterfacesCasosDeUso.IPublicacionVenta;
using CasosDeUsos.DTOs.PublicacionVentaDTO;
using System.Reflection.PortableExecutable;
using CasosDeUsos.InterfacesCasosDeUso.IPublicacionVentaCasosDeUso;
using ExcepcionesPropias.ExceptionMaquinarias;
using ExcepcionesPropias.ExeptionDireccion;
using ExcepcionesPropias.ExceptionCaracteristicas;


namespace WebAgro.Controllers
{
    public class PublicacionController : Controller
    {
        public ICUListadoPublicacionesVenta CUListadoPublicacionesVenta { get; set; }
        public ICUBuscarPublicacionEnVenta CUBuscarPublicacionEnVenta { get; set; }
        public ICUAltaCaracteristica CUAltaCaracteristica { get; set; }//alta funcionando
        public ICUAltaDireccion CUAltaDireccion { get; set; }//alta funcionando
        public ICUAltaMaquinariaTractor CUAltaMaquinariaTractor { get; set; }//alta funcionando, trae los datos de dir y caract.. con ids.
        public ICUAltaMaquinariaSembradora CUAltaMaquinariaSembradora { get; set; }
        public ICUAltaMaquinariaCosechadora CUAltaMaquinariaCosechadora { get; set; }
        public ICUAltaPublicacionVenta CUAltaPublicacionVenta {  get; set; }
        public ICUAltaMaquinariaFertilizadora CUAltaMaquinariaFertilizadora { get; set; }//faltante

        private readonly IWebHostEnvironment _webHostEnvironment;

        // Constructor con inyección de dependencias
        public PublicacionController(ICUListadoPublicacionesVenta cUListadoPublicacionesVenta, ICUBuscarPublicacionEnVenta cUBuscarPublicacionEnVenta,
            IWebHostEnvironment webHostEnvironment,ICUAltaCaracteristica cUAltaCaracteristica, ICUAltaDireccion cUAltaDireccion, ICUAltaMaquinariaTractor cUAltaMaquinariaTractor,
            ICUAltaPublicacionVenta cUAltaPublicacionVenta, ICUAltaMaquinariaFertilizadora cUAltaMaquinariaFertilizadora, ICUAltaMaquinariaSembradora cUAltaMaquinariaSembradora
,           ICUAltaMaquinariaCosechadora cUAltaMaquinariaCosechadora)
        {
            _webHostEnvironment = webHostEnvironment;
            CUAltaCaracteristica = cUAltaCaracteristica;
            CUAltaDireccion = cUAltaDireccion;

            CUAltaPublicacionVenta = cUAltaPublicacionVenta;
            CUListadoPublicacionesVenta = cUListadoPublicacionesVenta;
            CUBuscarPublicacionEnVenta = cUBuscarPublicacionEnVenta;

            CUAltaMaquinariaTractor = cUAltaMaquinariaTractor;
            CUAltaMaquinariaFertilizadora = cUAltaMaquinariaFertilizadora;
            CUAltaMaquinariaSembradora = cUAltaMaquinariaSembradora;
            CUAltaMaquinariaCosechadora = cUAltaMaquinariaCosechadora;
        }

        public IActionResult TodasLasPublicacionesEnVenta()
        {
            
            IEnumerable<ListadoPublicacionesEnVentaDTO> listadoPublicacionesEnVentaDTOs = new List<ListadoPublicacionesEnVentaDTO>();
            try
            {
                listadoPublicacionesEnVentaDTOs = CUListadoPublicacionesVenta.Ejecutar();
                return View(listadoPublicacionesEnVentaDTOs);
            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return View();
            }

        }

        public ActionResult DetallePublicacionEnVenta(int id)
        {
            DetallePublicacionEnVentaDTO detallePublicacionEnVentaDTO = new DetallePublicacionEnVentaDTO();

            try
            {
                detallePublicacionEnVentaDTO = CUBuscarPublicacionEnVenta.Ejecutar(id);
                return View(detallePublicacionEnVentaDTO);
            }
            catch (Exception ex) 
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("TodasLasPublicacionesEnVenta");
            }

        }
        public IActionResult SeleccionarTipoMaquinaria()
        {
           
            return View();
        }



        #region Formulario para dar de alta un tractor FUNCIONANDO
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

                  CUAltaCaracteristica.Ejecutar(caracteristicaDTO);

                // guardo el id en Session
                HttpContext.Session.SetInt32("CaracteristicaId", caracteristicaDTO.Id);

                return Redirect("FormularioTractorDireccion");

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

                  CUAltaDireccion.Ejecutar(direccionDTO);
                //Al crear el objeto (DireccionDTO) todavía no tiene un Id válido.
                //El Id se asigna recién después de ejecutar
                HttpContext.Session.SetInt32("DireccionId", direccionDTO.Id);

                return Redirect("FormularioTractorMaquinaria");
              
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


                //// Recupero los Ids de Característica y Dirección de la Session
                int? caracteristicaId = HttpContext.Session.GetInt32("CaracteristicaId");
                int? direccionId = HttpContext.Session.GetInt32("DireccionId");

                if (!caracteristicaId.HasValue || !direccionId.HasValue)
                {
                    TempData["Error"] = "Faltan datos de Característica o Dirección.";
                    return RedirectToAction("FormularioTractorMaquinaria");
                }

                // Asigno los Ids al DTO para que el CU pueda relacionarlos
                tractorDTO.CaracteristicaId = caracteristicaId.Value;
                tractorDTO.DireccionId = direccionId.Value;


                CUAltaMaquinariaTractor.Ejecutar(tractorDTO);

                // guardo el id en Session
                HttpContext.Session.SetInt32("tractorId", tractorDTO.Id);


                return Redirect("FormularioTractorPublicacionVenta");

                
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
        public async Task<IActionResult> FormularioTractorAltaPublicacionVenta(VentaDTO ventaDTO, IFormFile fotoArchivo)
        {
            try
            {
                string Email = HttpContext.Session.GetString("EmailUsuario");

                int? maquinariaId = HttpContext.Session.GetInt32("tractorId");


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

                    ventaDTO.Foto = "/uploads/" + uniqueFileName;
                }
                else
                {
                    // Opcional: poner una imagen por defecto si no se subió ninguna foto
                    ventaDTO.Foto = "/images/default-maquinaria.jpg";
                }


                if (!maquinariaId.HasValue )
                {
                    TempData["Error"] = "Faltan datos de Maquinaria.";
                    return RedirectToAction("FormularioTractorPublicacionVenta");
                }

                // Asigno los Ids al DTO para que el CU pueda relacionarlos
                ventaDTO.MaquinariaId = maquinariaId.Value;

                Console.WriteLine(ventaDTO.Foto);
                CUAltaPublicacionVenta.Ejecutar(ventaDTO,Email);
                ViewBag.Exito = "✅ Maquinaria Tractor publicada con éxito";
                return View("FormularioTractorPublicacionVenta");
                //return RedirectToAction("ObtenerMaquinariaPorId", new { id = venta.IdPublicacion });
            }
            catch(ArgumentNullException aex)
            {
                TempData["Error"] = aex.Message;

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return Redirect("FormularioTractorPublicacionVenta");

        }
        #endregion


        #region Formulario para dar de alta una Sembradora FUNCIONANDO
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


                CUAltaCaracteristica.Ejecutar(caracteristicaDTO);


                // guardo el id en Session
                HttpContext.Session.SetInt32("CaracteristicaId", caracteristicaDTO.Id);

                return Redirect("FormularioSembradoraDireccion");
                

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


                    CUAltaDireccion.Ejecutar(direccionDTO);
                //El Id se asigna recién después de ejecutar
                HttpContext.Session.SetInt32("DireccionId", direccionDTO.Id);

                return Redirect("FormularioSembradoraMaquinaria");
                
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

                //// Recupero los Ids de Característica y Dirección de la Session
                int? caracteristicaId = HttpContext.Session.GetInt32("CaracteristicaId");
                int? direccionId = HttpContext.Session.GetInt32("DireccionId");

                if (!caracteristicaId.HasValue || !direccionId.HasValue)
                {
                    TempData["Error"] = "Faltan datos de Característica o Dirección.";
                    return RedirectToAction("FormularioTractorMaquinaria");
                }

                // Asigno los Ids al DTO para que el CU pueda relacionarlos
                sembradoraDTO.CaracteristicaId = caracteristicaId.Value;
                sembradoraDTO.DireccionId = direccionId.Value;



                CUAltaMaquinariaSembradora.Ejecutar(sembradoraDTO);

                // guardo el id en Session
                HttpContext.Session.SetInt32("SembradoraId", sembradoraDTO.Id);

                return Redirect("FormularioSembradoraPublicacionVenta");
                
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormularioSembradoraAltaPublicacionVenta(VentaDTO ventaDTO, IFormFile fotoArchivo)//parametro para guardar fotos
        {
            try
            {
                string Email = HttpContext.Session.GetString("EmailUsuario");

                int? maquinariaId = HttpContext.Session.GetInt32("SembradoraId");

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

                    ventaDTO.Foto = "/uploads/" + uniqueFileName;
                }
                else
                {
                    // Opcional: poner una imagen por defecto si no se subió ninguna foto
                    ventaDTO.Foto = "/images/default-maquinaria.jpg";
                }


                if (!maquinariaId.HasValue)
                {
                    TempData["Error"] = "Faltan datos de Maquinaria.";
                    return RedirectToAction("FormularioTractorPublicacionVenta");
                }

                // Asigno los Ids al DTO para que el CU pueda relacionarlos
                ventaDTO.MaquinariaId = maquinariaId.Value;

                Console.WriteLine(ventaDTO.Foto);
                CUAltaPublicacionVenta.Ejecutar(ventaDTO, Email);
                ViewBag.Exito = "✅ Maquinaria Sembradora publicada con éxito";
                return View("FormularioTractorPublicacionVenta");
                //return RedirectToAction("ObtenerMaquinariaPorId", new { id = venta.IdPublicacion });
            }
            catch (ArgumentNullException aex)
            {

                TempData["Error"] = aex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return Redirect("FormularioSembradoraPublicacionVenta");

        }
        #endregion

        #region Formulario para dar de alta una Fertilizadora FUNCIONANDO
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

           
                    CUAltaCaracteristica.Ejecutar(caracteristicaDTO);

                HttpContext.Session.SetInt32("CaracteristicaId", caracteristicaDTO.Id);

                return Redirect("FormularioFertilizadoraDireccion");


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

                    CUAltaDireccion.Ejecutar(direccionDTO);

                HttpContext.Session.SetInt32("DireccionId", direccionDTO.Id);

                return Redirect("FormularioFertilizadoraMaquinaria");
                
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

                //// Recupero los Ids de Característica y Dirección de la Session
                int? caracteristicaId = HttpContext.Session.GetInt32("CaracteristicaId");
                int? direccionId = HttpContext.Session.GetInt32("DireccionId");

                if (!caracteristicaId.HasValue || !direccionId.HasValue)
                {
                    TempData["Error"] = "Faltan datos de Característica o Dirección.";
                    return RedirectToAction("FormularioTractorMaquinaria");
                }

                // Asigno los Ids al DTO para que el CU pueda relacionarlos
                fertilizadoraDTO.CaracteristicaId = caracteristicaId.Value;
                fertilizadoraDTO.DireccionId = direccionId.Value;


                CUAltaMaquinariaFertilizadora.Ejecutar(fertilizadoraDTO);

                HttpContext.Session.SetInt32("FertilizadoraId", fertilizadoraDTO.Id);

                return Redirect("FormularioFertilizadoraPublicacionVenta");
                
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
        public async Task<IActionResult> FormularioFertilizadoraAltaPublicacionVenta(VentaDTO ventaDTO, IFormFile fotoArchivo)//parametro para guardar fotos
        {
            try
            {
                string Email = HttpContext.Session.GetString("EmailUsuario");

                int? maquinariaId = HttpContext.Session.GetInt32("FertilizadoraId");

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

                    ventaDTO.Foto = "/uploads/" + uniqueFileName;
                }
                else
                {
                    // Opcional: poner una imagen por defecto si no se subió ninguna foto
                    ventaDTO.Foto = "/images/default-maquinaria.jpg";
                }


                if (!maquinariaId.HasValue)
                {
                    TempData["Error"] = "Faltan datos de Maquinaria.";
                    return RedirectToAction("FormularioTractorPublicacionVenta");
                }

                // Asigno los Ids al DTO para que el CU pueda relacionarlos
                ventaDTO.MaquinariaId = maquinariaId.Value;

                Console.WriteLine(ventaDTO.Foto);
                CUAltaPublicacionVenta.Ejecutar(ventaDTO, Email);
                ViewBag.Exito = "✅ Maquinaria Fertilizadora publicada con éxito";
                return View("FormularioFertilizadoraPublicacionVenta");
                //return RedirectToAction("ObtenerMaquinariaPorId", new { id = venta.IdPublicacion });


            }
            catch(ArgumentNullException aex)
            {

                TempData["Error"] = aex.Message;
                return Redirect("FormularioFertilizadoraPublicacionVenta");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect("FormularioFertilizadoraPublicacionVenta");
            }
        }
        #endregion

        #region Formulario para dar de alta una Cosechadora FUNCIONANDO

        public IActionResult FormularioCosechadoraCaracteristicas()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioCosechadoraAltaCaracteristicas(CaracteristicaDTO caracteristicaDTO)
        {
            try
            {


                CUAltaCaracteristica.Ejecutar(caracteristicaDTO);

                HttpContext.Session.SetInt32("CaracteristicaId", caracteristicaDTO.Id);

                return Redirect("FormularioCosechadoraDireccion");


            }
            catch (CaracteristicaException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("FormularioCosechadoraCaracteristicas");

        }

        public IActionResult FormularioCosechadoraDireccion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioCosechadoraAltaDireccion(DireccionDTO direccionDTO)
        {
            try
            {

                CUAltaDireccion.Ejecutar(direccionDTO);

                HttpContext.Session.SetInt32("DireccionId", direccionDTO.Id);

                return Redirect("FormularioCosechadoraMaquinaria");

            }
            catch (DireccionException ex)
            {
                TempData["Error"] = ex.Message;

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("FormularioCosechadoraDireccion");


        }

        public IActionResult FormularioCosechadoraMaquinaria()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioCosechadoraAltaMaquinaria(CosechadoraDTO cosechadoraDTO)
        {
            try
            {

                //// Recupero los Ids de Característica y Dirección de la Session
                int? caracteristicaId = HttpContext.Session.GetInt32("CaracteristicaId");
                int? direccionId = HttpContext.Session.GetInt32("DireccionId");

                if (!caracteristicaId.HasValue || !direccionId.HasValue)
                {
                    TempData["Error"] = "Faltan datos de Característica o Dirección.";
                    return RedirectToAction("FormularioCosechadoraMaquinaria");
                }

                // Asigno los Ids al DTO para que el CU pueda relacionarlos
                cosechadoraDTO.CaracteristicaId = caracteristicaId.Value;
                cosechadoraDTO.DireccionId = direccionId.Value;


                CUAltaMaquinariaCosechadora.Ejecutar(cosechadoraDTO);

                HttpContext.Session.SetInt32("CosechadoraId", cosechadoraDTO.Id);

                return Redirect("FormularioCosechadoraPublicacionVenta");

            }
            catch (MaquinariaFertilizadoraException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("FormularioCosechadoraMaquinaria");


        }

        public IActionResult FormularioCosechadoraPublicacionVenta()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FormularioCosechadoraAltaPublicacionVenta(VentaDTO ventaDTO, IFormFile fotoArchivo)//parametro para guardar fotos
        {
            try
            {
                string Email = HttpContext.Session.GetString("EmailUsuario");

                int? maquinariaId = HttpContext.Session.GetInt32("CosechadoraId");

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

                    ventaDTO.Foto = "/uploads/" + uniqueFileName;
                }
                else
                {
                    // Opcional: poner una imagen por defecto si no se subió ninguna foto
                    ventaDTO.Foto = "/images/default-maquinaria.jpg";
                }


                if (!maquinariaId.HasValue)
                {
                    TempData["Error"] = "Faltan datos de Maquinaria.";
                    return RedirectToAction("FormularioCosechadoraPublicacionVenta");
                }

                // Asigno los Ids al DTO para que el CU pueda relacionarlos
                ventaDTO.MaquinariaId = maquinariaId.Value;

                Console.WriteLine(ventaDTO.Foto);
                CUAltaPublicacionVenta.Ejecutar(ventaDTO, Email);
                ViewBag.Exito = "✅ Maquinaria Cosechadora publicada con éxito";
                return View("FormularioCosechadoraPublicacionVenta");
                //return RedirectToAction("ObtenerMaquinariaPorId", new { id = venta.IdPublicacion });


            }
            catch (ArgumentNullException aex)
            {

                TempData["Error"] = aex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return Redirect("FormularioCosechadoraPublicacionVenta");

        }
        #endregion



        //[HttpPost]
        //public IActionResult FiltradoPorMarcaDeMaquinaria(string marca)
        //{
        //    try
        //    {
        //        List<Publicacion> VerPorMarca = sistema.ObtenerMaquinariaPorMarca(marca);
        //        return View(VerPorMarca);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Error"] = ex.Message;
        //        return Redirect("TodasLasPublicacionesEnVenta");
        //    }
        //}


        ////Filtrados por Maquinaria:
        //public IActionResult FiltrarPorTipoTractor()
        //{
        //    List<Venta> FiltradoPorTractoresEnVenta = sistema.ObtenerListaDeTractoresEnVenta();
        //    return View(FiltradoPorTractoresEnVenta);

        //}

        //public IActionResult FiltrarPorTipoSembradora()
        //{
        //    List<Venta> FiltradoPorSembradorasEnVenta = sistema.ObtenerListaDeSembradorasEnVenta();

        //    return View(FiltradoPorSembradorasEnVenta);
        //}

        //public IActionResult FiltrarPorTipoFertilizadora()
        //{
        //    List<Venta> FiltradoPorFertilizadorasEnVenta = sistema.ObtenerListaDeFertilizadorasEnVenta();

        //    return View(FiltradoPorFertilizadorasEnVenta);
        //}
        //#endregion



    }
}
