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
        public Sembradora(string categoria, Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas) : 
            base(direccion, caracteristica, otrasCaracteristicas)
        { }
        public override string TipoVechiculo()
        {
            string dato = $"Sembradora\n" +
                $"Tipo de sembradora: {TipoDeSembradora}\n" +
                $"caracteristicas: {Caracteristica.Marca}\n" +
                $"caracteristicas: {Caracteristica.Modelo}\n" +
                $"caracteristicas: {Caracteristica.Anio}\n"; 
            return dato;
        }

        public override string ToString()
        {
            return TipoVechiculo();
        }
    }
}
