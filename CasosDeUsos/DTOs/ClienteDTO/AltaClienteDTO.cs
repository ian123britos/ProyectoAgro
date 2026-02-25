using Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.ClienteDTO
{
    public class AltaClienteDTO:AltaUsuarioClienteDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
    }
}
