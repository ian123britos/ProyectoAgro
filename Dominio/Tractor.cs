using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tractor : Maquinaria
    {
        public override string TipoVechiculo()
        {
            string dato = "Tractor";
            return dato;
        }
    }
}
