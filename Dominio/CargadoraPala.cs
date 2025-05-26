using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public class CargadoraPala : Maquinaria
    {
        public int Cilindro {  get; set; }
        public string MarcaMotor { get; set; }

        public CargadoraPala() { }
        public CargadoraPala(int cilindro,string marcaMotor, Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas) :
            base(direccion, caracteristica, otrasCaracteristicas)
        {
            Cilindro = cilindro;
            MarcaMotor = marcaMotor;
        
        }

        public override string TipoVechiculo()
        {
            string dato = $"Cargadora de pala:\n" +
                $" Cilindro {Cilindro}\n" +
                $"caracteristicas: {Caracteristica.Marca}\n" +
                $"caracteristicas: {Caracteristica.Modelo}\n" +
                $"caracteristicas: {Caracteristica.Anio}\n" +
                $"marca del motor {MarcaMotor}\n" +
                $"caracteristicas: {Caracteristica.TipoDeCombustible} ";
                
            return dato;
        }

        public override string ToString()
        {
            return TipoVechiculo();
        }
    }

}
