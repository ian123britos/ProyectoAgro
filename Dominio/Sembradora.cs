using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sembradora : Maquinaria
    {
        public string TipoDeSembradora {  get; set; }
        public Sembradora() { }
        public Sembradora(string tipoSembradora,string categoria, Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas) : 
            base(direccion, caracteristica, otrasCaracteristicas)
        {
            TipoDeSembradora = tipoSembradora;
        }
        public override string TipoVechiculo() => "Sembradora";

        public override string ToString()
        {
            return TipoVechiculo();
        }
    }
}
