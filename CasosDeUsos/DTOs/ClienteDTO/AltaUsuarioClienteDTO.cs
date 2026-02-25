using Dominio.EntidadesNegocio;
using Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.ClienteDTO
{
    public class AltaUsuarioClienteDTO
    {
        public int Id {  get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public int RolId { get; set; }
    }
}
