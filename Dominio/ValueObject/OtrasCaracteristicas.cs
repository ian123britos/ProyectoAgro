using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObject
{
    public class OtrasCaracteristicas : IValidable
    {
        public string CaracteristicasFaltantes { get; private set; }

        public OtrasCaracteristicas(string caracteristicasFaltantes)
        {
            CaracteristicasFaltantes = caracteristicasFaltantes;
            Validar();
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(CaracteristicasFaltantes))
            {
                throw new Exception("Otras caracteristicas no puede ser vacio");
            }
            if (CaracteristicasFaltantes.Length > 60)
            {
                throw new Exception("Otras características debe de ser menor a 60 caracteres");

            }
        }
    }
}
