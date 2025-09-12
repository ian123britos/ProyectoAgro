using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.DireccionDTO
{
    public class DireccionDTO
    {
        public int IdDireccion { get; private set; }
        public static int UltimoIdDireccion { get; set; } = 1;
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
    }
}
