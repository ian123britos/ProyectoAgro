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
        public int IdMaquinaria { get; private set; }
        public static int UltimoIdMaquinaria;
        public Direccion Direccion { get; set; }
        public Caracteristica Caracteristica { get; set; }
        public OtrasCaracteristicas OtrasCaracteristicas { get; set; }


        public Maquinaria()
        {
            IdMaquinaria = UltimoIdMaquinaria++;

        }
        public Maquinaria(Direccion direccion, Caracteristica caracteristica, string otrasCaracteristicas)
        {
            IdMaquinaria = UltimoIdMaquinaria++;
            Direccion = direccion;
            Caracteristica = caracteristica;
            OtrasCaracteristicas = new OtrasCaracteristicas(otrasCaracteristicas);

        }
        public abstract string TipoVechiculo();


       
    }
}
