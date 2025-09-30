using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Tractor : Maquinaria
    {
        public bool TieneCabina { get; set; }
        protected Tractor() :base() { }
        public Tractor(bool tieneCabina, Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas) :
            base(direccion, caracteristica, otrasCaracteristicas)
        {
            TieneCabina = tieneCabina;
        }

        public override string TipoVechiculo() => "Tractor";


        public static string TieneSiNo(bool EsConCabina)
        {
            string texto = "";
            if (EsConCabina == false)
            {
                texto = "No";

            }
            else
            {
                texto = "Si";

            }
            return texto;
        }
    }
}
