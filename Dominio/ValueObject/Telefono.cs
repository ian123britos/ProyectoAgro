using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObject
{
    [ComplexType ]
    public record Telefono : IValidable
    {
        public int Tel { get; private set; }

        public Telefono(int tel)
        {
            Tel = tel;
            Validar();
        }

        public void Validar()
        {
            // Convertimos a string por si Telefono es int
            string telefonoStr = Tel.ToString();

            if (string.IsNullOrWhiteSpace(telefonoStr))
            {
                throw new Exception("El número de teléfono no puede estar vacío");
            }

            if (telefonoStr.Length != 9 || !telefonoStr.All(char.IsDigit))
            {
                throw new Exception("Ingresa un número de teléfono válido con 9 dígitos");
            }
        }

    }
}
