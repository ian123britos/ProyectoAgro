using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CargadoraPala : Maquinaria
    {
        public int Cilindro {  get; set; }
        public string MarcaMotor { get; set; }

        public CargadoraPala(int cilindro,string marcaMotor, string categoria, string marca, string modelo, DateTime anio,
            int precioVenta, string pais, string ciudad, string barrio, int horasDeUso, bool esUsado, TipoDireccion tipoDireccion,
            bool unicoDuenio, TipoCombustible tipoCombustible, string otrasCaracteristicas) : base(categoria, marca, modelo, anio, precioVenta, pais, ciudad, barrio, horasDeUso,
                esUsado, tipoDireccion, unicoDuenio, tipoCombustible, otrasCaracteristicas)  
        {
            Cilindro = cilindro;
            MarcaMotor = marcaMotor;
        
        }

        public override string TipoVechiculo()
        {
            string dato = "Cargadora de pala";
            return dato;
        }
    }

}
