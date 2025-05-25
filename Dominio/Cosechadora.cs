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

        public Cosechadora(string tipoCosechadora,int capacidadDeCarga,bool esRuedaDual,string categoria, string marca, string modelo, DateTime anio,
            int precioVenta, string pais, string ciudad, string barrio, int horasDeUso, bool esUsado, TipoDireccion tipoDireccion,
            bool unicoDuenio, TipoCombustible tipoCombustible, string otrasCaracteristicas) : base(categoria, marca, modelo, anio, precioVenta, pais, ciudad, barrio, horasDeUso,
                esUsado, tipoDireccion, unicoDuenio, tipoCombustible, otrasCaracteristicas)
        { 
            TipoCosechadora = tipoCosechadora;
            CapacidadDeCarga = capacidadDeCarga;
            EsRuedaDual = esRuedaDual;
        }

        public override string TipoVechiculo()
        {
            string dato = "Cosechadora";
            return dato;
        }
    }
}
