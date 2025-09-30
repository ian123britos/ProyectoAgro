using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObject
{
    [ComplexType]
    public record OtrasCaracteristicas : IValidable
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
