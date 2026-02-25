using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.MaquinariaDTO
{
    public class TractorDTO:MaquinariaDTO
    {
        public bool TieneCabina { get; set; }
        // Propiedades para relacionar con entidades existentes
        public int CaracteristicaId { get; set; }
        public int DireccionId { get; set; }
    }
}
