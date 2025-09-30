using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.DireccionDTO
{
    public class DireccionDTO
    {
        public int Id { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
    }
}
