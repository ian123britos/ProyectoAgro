using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.MaquinariaDTO
{
    public class CargadoraDePalaDTO:MaquinariaDTO
    {
        public int Cilindro { get; set; }
        public string MarcaMotor { get; set; }
    }
}
