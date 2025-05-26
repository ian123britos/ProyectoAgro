using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Maquinaria
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 0;   
        public Direccion Direccion { get; set; }
        public Caracteristica Caracteristica { get; set; }
        public string OtrasCaracteristicas { get; set; }
        

        public Maquinaria() 
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Maquinaria(Direccion direccion,Caracteristica caracteristica,string otrasCaracteristicas)
        {
            Direccion = direccion;
            Caracteristica = caracteristica;
            OtrasCaracteristicas = otrasCaracteristicas;

        }

        public abstract string TipoVechiculo();

        public void Validar()
        {
            ValidarOtrasCaracteristicas();

        }

        private void ValidarOtrasCaracteristicas()
        {
            if(OtrasCaracteristicas.Length > 60)
            {
                throw new Exception("Otras caracteristicas debe de ser menor a 60 caracteres")
            }
        }
    }
}
