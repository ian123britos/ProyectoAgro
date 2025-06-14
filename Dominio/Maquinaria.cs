
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public abstract class Maquinaria :IValidable
    {
       public int IdMaquinaria {  get; set; }
        public static int UltimoIdMaquinaria { get; set; }
        public Direccion Direccion { get; set; }
        public Caracteristica Caracteristica { get; set; }
        public string OtrasCaracteristicas { get; set; }
        

        public Maquinaria() 
        {
            IdMaquinaria = UltimoIdMaquinaria++;

        }
        public Maquinaria(Direccion direccion,Caracteristica caracteristica,string otrasCaracteristicas)
        {
            IdMaquinaria = UltimoIdMaquinaria++;
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

            if (OtrasCaracteristicas.Length > 60)
            {
                throw new Exception("Otras características debe de ser menor a 60 caracteres");

            }

            int i = 0;
                while(i < OtrasCaracteristicas.Length)
                {
                    if (OtrasCaracteristicas[i] >= '0' && OtrasCaracteristicas[i] <= '9')
                    {
                        throw new Exception("Otras características no puede tener numero");
                    }
                    i++;
                }
        }
    }
}
