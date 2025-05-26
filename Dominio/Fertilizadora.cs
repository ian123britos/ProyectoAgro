using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Fertilizadora : Maquinaria
    {
        public string MarcaMotor {  get; set; }
        public int Potencia { get; set; }
        public bool DobleTraccion {  get; set; }

        public Fertilizadora() { }

        public Fertilizadora(string marcaMotor,int potencia,bool dobleTraccion,Direccion direccion,Caracteristica caracteristica, string otrasCaracteristicas) :
            base(direccion,caracteristica,otrasCaracteristicas)
        {
            MarcaMotor = marcaMotor;
            Potencia = potencia;
            DobleTraccion = dobleTraccion;
        }
        public override string TipoVechiculo()
        {
            string TieneDobleTraccion = EsDobleTraccion(DobleTraccion);
            string dato = $"Fertilizadora\n" +
                $"marca del motor: {MarcaMotor}" +
                $"potencia: {Potencia}\n" +
                $"es doble traccion: {TieneDobleTraccion}\n" +
                $"caracteristicas: {Caracteristica.Marca}\n" +
                $"caracteristicas: {Caracteristica.Modelo}\n" +
                $"caracteristicas: {Caracteristica.Anio}\n";
            return dato;
        }
        public override string ToString()
        {
            return TipoVechiculo();
        }
        public static string EsDobleTraccion(bool esDobleTraccion)
        {
            string Texto = "";
            if(esDobleTraccion == false)
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
