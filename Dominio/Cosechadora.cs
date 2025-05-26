using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cosechadora : Maquinaria
    {
        public string TipoCosechadora {  get; set; }
        public int CapacidadDeCarga { get; set; }
        public bool EsRuedaDual { get; set; }

        public Cosechadora() { }
        public Cosechadora(string tipoCosechadora,int capacidadDeCarga,bool esRuedaDual, Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas) :
            base(direccion, caracteristica, otrasCaracteristicas)
        { 
            TipoCosechadora = tipoCosechadora;
            CapacidadDeCarga = capacidadDeCarga;
            EsRuedaDual = esRuedaDual;
        }

        public override string TipoVechiculo()
        {
            string ruedaDual = ObtenerSiNo(EsRuedaDual);
            string dato = $"Cosechadora\n" +
                $"es rueda dual {ruedaDual}" +
                $"capacidad de carga: {CapacidadDeCarga}" +
                $"tipo de cosechadora {TipoCosechadora}" +
                $"caracteristicas: {Caracteristica.Marca}\n" +
                $"caracteristicas: {Caracteristica.Modelo}\n" +
                $"caracteristicas: {Caracteristica.Anio}\n";
            return dato;
        }

        public override string ToString()
        {
            return TipoVechiculo();
        }

        public static string ObtenerSiNo(bool esDual)
        {
            string Texto = "";
            if(esDual == false)
            {
                Texto = "No";
            }else
            {
                Texto = "Si";
            }
            return Texto;
        }
    }
}
