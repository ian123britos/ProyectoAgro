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

        public Fertilizadora(string marcaMotor,int potencia, bool dobleTraccion, string categoria, string marca, string modelo, DateTime anio, 
            int precioVenta, string pais, string ciudad, string barrio, int horasDeUso,bool esUsado, TipoDireccion tipoDireccion, 
            bool unicoDuenio, TipoCombustible tipoCombustible, string otrasCaracteristicas) : base(categoria,marca,modelo,anio,precioVenta,pais,ciudad,barrio,horasDeUso,
                esUsado,tipoDireccion,unicoDuenio,tipoCombustible,otrasCaracteristicas) 
        {
            MarcaMotor = marcaMotor;
            Potencia = potencia;
            DobleTraccion = dobleTraccion;
        }
        public override string TipoVechiculo()
        {
            string dato = "Fertilizadora";
            return dato;
        }
    }
}
