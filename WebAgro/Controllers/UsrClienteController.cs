using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebAgro.Controllers
{
    public class UsrClienteController : Controller
    {
        private readonly Sistema sistema;
        public UsrClienteController()
        {
            sistema = Sistema.ObtenerInstancia();
        }
        public IActionResult FormularioRegistro()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RegistroUsuarioCliente(Cliente cliente)
        {
            try
            {
                sistema.AltaUsuario(cliente);
                return Redirect("FormularioLogin");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("FormularioRegistro");
            }
        }

        public IActionResult FormularioLogin()
        {
            return View();
        }
    }
}
