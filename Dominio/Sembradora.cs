using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sembradora : Maquinaria
    {
        public override string TipoVechiculo()
        {
            string dato = "Sembradora";
            return dato;
        }
    }
}
