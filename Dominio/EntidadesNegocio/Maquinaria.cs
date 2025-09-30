using Dominio.Interfaces;
using Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.EntidadesNegocio
{
    public abstract class Maquinaria 
    {
        public int Id { get; private set; }
        public Direccion Direccion { get; set; }
        public Caracteristica Caracteristica { get; set; }
        public OtrasCaracteristicas OtrasCaracteristicas { get; set; }


        protected Maquinaria()
        {

        }
        public Maquinaria(Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas)
        {
            Direccion = direccion;
            Caracteristica = caracteristica;
            OtrasCaracteristicas = new OtrasCaracteristicas(otrasCaracteristicas);

        }
        public abstract string TipoVechiculo();


       
    }
}
