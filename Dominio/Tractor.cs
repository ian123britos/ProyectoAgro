using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tractor : Maquinaria
    {
        public bool TieneCabina { get; set; }
        public Tractor() { }
        public Tractor(bool tieneCabina,Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas) : 
            base(direccion, caracteristica, otrasCaracteristicas)
        { 
            TieneCabina = tieneCabina;
        }

        public override string TipoVechiculo()
        {
                string tendraCabina = TieneSiNo(TieneCabina);
                string dato = $"Tractor\n" +
                $"Tiene cabina: {tendraCabina}\n" +
                $"caracteristicas: {Caracteristica.Marca}\n" +
                $"caracteristicas: {Caracteristica.Modelo}\n" +
                $"caracteristicas: {Caracteristica.Anio}\n";

            return dato;
        }

        public override string ToString()
        {
            return TipoVechiculo();
        }

        public static string TieneSiNo(bool EsConCabina)
        {
            string texto = "";
            if(EsConCabina == false)
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
