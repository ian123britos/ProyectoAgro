using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class CargadoraPala : Maquinaria
    {
        public int Cilindro { get; set; }
        public string MarcaMotor { get; set; }

        protected CargadoraPala() : base() { }
        public CargadoraPala(int cilindro, string marcaMotor, Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas) :
            base(direccion, caracteristica, otrasCaracteristicas)
        {
            Cilindro = cilindro;
            MarcaMotor = marcaMotor;

        }

        public override string TipoVechiculo() => "CargadoraDePala";


        //public override string ToString()
        //{
        //    return TipoVechiculo();
        //}
    }

}
