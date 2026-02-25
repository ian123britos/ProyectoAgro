using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.ClienteDTO
{
    public class LoginUsuarioDTO
    {
        public string Email { get; set; }
        public string Contrasenia { get; set; }

    }
}
