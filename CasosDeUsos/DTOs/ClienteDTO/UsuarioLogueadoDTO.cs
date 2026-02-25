using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.ClienteDTO
{
    public class UsuarioLogueadoDTO
    {
        public string Email {  get; set; }
        public Rol Rol { get; set; } 
        public string Token { get; set; }
    }
}
