using Dominio.Interfaces;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Sembradora : Maquinaria,IValidable
    {
        public string TipoDeSembradora { get; set; }
        public Sembradora() { }
        public Sembradora(string tipoSembradora, Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas) :
            base(direccion, caracteristica, otrasCaracteristicas)
        {
            TipoDeSembradora = tipoSembradora;
            Validar();
        }
        public void Validar()
        {
            if(string.IsNullOrEmpty(TipoDeSembradora))
            {
                throw new MaquinariaSembradoraException("El campo tipo de sembradora no puede ser vacio");
            }
        }
        public override string TipoVechiculo() => "Sembradora";

        public override string ToString()
        {
            return TipoVechiculo();
        }
    }
}
