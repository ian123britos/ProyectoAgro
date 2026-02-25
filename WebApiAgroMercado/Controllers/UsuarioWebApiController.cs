using CasosDeUsos.DTOs.ClienteDTO;
using CasosDeUsos.InterfacesCasosDeUso.IUsuarioCasosDeUso;
using ExcepcionesPropias.ExceptionGenericas;
using ExcepcionesPropias.ExceptionUsuarios;
using Microsoft.AspNetCore.Mvc;
using WebApiAgroMercado.Token;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAgroMercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioWebApiController : ControllerBase
    {
        public ICUAltaUsuarioCliente CUAltaUsuarioCliente { get; set; }
        public ICUBuscarUsuario CUBuscarUsuarioCliente { get; set; }
        public ICULoginUsuario CULoginUsuario { get; set; }

        public UsuarioWebApiController(ICUAltaUsuarioCliente cUAltaUsuarioCliente,ICUBuscarUsuario cUBuscarUsuarioCliente, ICULoginUsuario cULoginUsuario)
        {
            CUAltaUsuarioCliente = cUAltaUsuarioCliente;
            CUBuscarUsuarioCliente = cUBuscarUsuarioCliente;
            CULoginUsuario = cULoginUsuario;
        }


        // GET: api/<UsuarioWebApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioWebApiController>/5

        [HttpGet("{id}",Name ="GetUsuarioPorId")]
        public IActionResult GetUsuarioPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id es incorrecto");
                }
                return Ok(CUBuscarUsuarioCliente.Ejecutar(id));

            }
            catch (UsuarioException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("LoginUsuario")]
        public IActionResult Login([FromBody] LoginUsuarioDTO loginUsuarioDTO)
        {
            try
            {
                if (loginUsuarioDTO == null)
                {
                    return BadRequest("Datos incorrectos");
                }

                UsuarioLogueadoDTO usuarioLogueadoDTO = CULoginUsuario.Ejecutar(loginUsuarioDTO);
                if (usuarioLogueadoDTO != null)
                {
                    usuarioLogueadoDTO.Token = ManejadorToken.CrearToken(usuarioLogueadoDTO);
                }
                return Ok(usuarioLogueadoDTO);
            }
            catch (AbandonedMutexException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error");
            }

        }

        // POST api/<UsuarioWebApiController>
        [HttpPost("RegistrarUsuario")]
        public IActionResult Post([FromBody] AltaClienteDTO altaClienteDTO)
        {
            if(altaClienteDTO ==  null)
            {
                return BadRequest("Datos incorrectos");
            }
            try
            {
                int id = CUAltaUsuarioCliente.Ejecutar(altaClienteDTO);
                return CreatedAtRoute("GetUsuarioPorId", new { id = altaClienteDTO.Id }, altaClienteDTO);
            }
            catch (UsuarioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ConflictException cx)
            {
                return Conflict(cx.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        // PUT api/<UsuarioWebApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioWebApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
