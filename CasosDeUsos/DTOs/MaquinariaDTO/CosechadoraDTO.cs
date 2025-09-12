using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.MaquinariaDTO
{
    public class CosechadoraDTO:MaquinariaDTO
    {
        public string TipoCosechadora { get; set; }
        public int CapacidadDeCarga { get; set; }
        public bool EsRuedaDual { get; set; }

    }
}
