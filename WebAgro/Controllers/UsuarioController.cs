using CasosDeUsos.DTOs.ClienteDTO;
using CasosDeUsos.InterfacesCasosDeUso.IUsuarioCasosDeUso;
using Dominio.EntidadesNegocio;
using ExcepcionesPropias.ExceptionGenericas;
using ExcepcionesPropias.ExceptionUsuarios;
using Microsoft.AspNetCore.Mvc;

namespace WebAgro.Controllers
{
    public class UsuarioController : Controller
    {
        public ICUAltaUsuarioCliente CUAltaUsuarioCliente { get; set; }
        public ICULoginUsuario CULoginUsuario { get; set; }

        public UsuarioController(ICUAltaUsuarioCliente cUAltaUsuarioCliente, ICULoginUsuario cULoginUsuario)
        {
            CUAltaUsuarioCliente = cUAltaUsuarioCliente;
            CULoginUsuario = cULoginUsuario;

        }

        public ActionResult FormularioRegistroUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaCliente(AltaClienteDTO altaClienteDTO)
        {



            try
            {
                

                CUAltaUsuarioCliente.Ejecutar(altaClienteDTO);
                return Redirect("FormularioLoginUsuario");
            }
            catch (UsuarioException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch(ConflictException ex)
            {
                TempData["Error"] = ex.Message;
            }
            return View("FormularioRegistroUsuario");

        }

        public ActionResult FormularioLoginUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUsuario(LoginUsuarioDTO loginUsuarioDTO)
        {
            //HttpContext.Session.SetString("EmailUsuario", loginUsuarioDTO.Email);
            //HttpContext.Session.SetInt32("RolUsuario", loginUsuarioDTO.);
            try
            {
                CULoginUsuario.Ejecutar(loginUsuarioDTO);
                return RedirectToAction("Publicacion", "SeleccionarTipoMaquinaria");
            }
            catch (UsuarioException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (NotFoundException ex)
            {
                TempData["Error"] = ex.Message;

            }
            catch (ConflictException ex)
            {
                TempData["Error"] = ex.Message;

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

            }
            return Redirect("FormularioLoginUsuario");

        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("FormularioLoginUsuario");
        }

    }
}
