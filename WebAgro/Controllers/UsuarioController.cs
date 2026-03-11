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

        #region Registrar un usuario
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
        #endregion


        public ActionResult FormularioLoginUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUsuario(LoginUsuarioDTO loginUsuarioDTO)
        {
           
            try
            {
                CULoginUsuario.Ejecutar(loginUsuarioDTO);
                HttpContext.Session.SetString("EmailUsuario", loginUsuarioDTO.Email);
               

                return RedirectToAction("TodasLasPublicacionesEnVenta", "Publicacion");
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
            HttpContext.Session.Remove("EmailUsuario");

            return RedirectToAction("FormularioLoginUsuario");
        }

    }
}
