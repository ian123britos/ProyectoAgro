using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.MaquinariaDTO
{
    public class FertilizadoraDTO:MaquinariaDTO
    {
        public string MarcaMotor { get; set; }
        public int Potencia { get; set; }
        public bool DobleTraccion { get; set; }
    }
}
