using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.PublicacionVentaDTO
{
    public class VentaDTO: PublicacionDTO
    {
        public DateTime FechaPublicacionVenta { get; set; }
        public double PrecioVenta { get; set; }
    }
}
