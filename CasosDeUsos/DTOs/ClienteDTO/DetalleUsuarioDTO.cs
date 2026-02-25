using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.ClienteDTO
{
    public class DetalleUsuarioDTO
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string TipoRol {  get; set; }
        public string Email { get; set; }
    }
}
