using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Cosechadora : Maquinaria
    {
        public string TipoCosechadora { get; set; }
        public int CapacidadDeCarga { get; set; }
        public bool EsRuedaDual { get; set; }

        protected Cosechadora() : base() { }
        public Cosechadora(string tipoCosechadora, int capacidadDeCarga, bool esRuedaDual, Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas) :
            base(direccion, caracteristica, otrasCaracteristicas)
        {
            TipoCosechadora = tipoCosechadora;
            CapacidadDeCarga = capacidadDeCarga;
            EsRuedaDual = esRuedaDual;
        }

        public override string TipoVechiculo() => "Cosechadora";

        //public override string ToString()
        //{
        //    return TipoVechiculo();
        //}

        public static string ObtenerSiNo(bool esDual)
        {
            string Texto = "";
            if (esDual == false)
            {
                Texto = "No";
            }
            else
            {
                Texto = "Si";
            }
            return Texto;
        }
    }
}
