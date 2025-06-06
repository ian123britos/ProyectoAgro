using D.Interfaces;
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
       
        public Direccion Direccion { get; set; }
        public Caracteristica Caracteristica { get; set; }
        public string OtrasCaracteristicas { get; set; }
        

        public Maquinaria() 
        {
          
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
