using Dominio.Interfaces;

using ExcepcionesPropias.ExceptionMaquinarias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Fertilizadora : Maquinaria,IValidable
    {
        public string MarcaMotor { get; set; }
        public int Potencia { get; set; }
        public bool DobleTraccion { get; set; }

        protected Fertilizadora() : base(){ }

        public Fertilizadora(string marcaMotor, int potencia, bool dobleTraccion, Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas) :
            base(direccion, caracteristica, otrasCaracteristicas)
        {
            MarcaMotor = marcaMotor;
            Potencia = potencia;
            DobleTraccion = dobleTraccion;
            Validar();
        }
        public void Validar()
        {
            ValidarMarcaMotor();
            ValidarPotencia();
        }

        private void ValidarPotencia()
        {
            if (Potencia <= 0)
            {
                throw new MaquinariaFertilizadoraException("La potencia de fertilizadora no puede ser 0 ni menor a 0");
            }
        }

        private void ValidarMarcaMotor()
        {
            if(string.IsNullOrEmpty(MarcaMotor))
            {
                throw new MaquinariaFertilizadoraException("La marca del motor de la fertilizadora no puede ser vacía");
            }
        }

        public override string TipoVehiculo() => "Fertilizadora";
        //public override string ToString()
        //{
        //    return TipoVechiculo();
        //}
        public static string EsDobleTraccion(bool esDobleTraccion)
        {
            string Texto = "";
            if (esDobleTraccion == false)
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
