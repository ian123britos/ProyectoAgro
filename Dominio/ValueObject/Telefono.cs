using Dominio.Interfaces;

using ExcepcionesPropias.ExceptionUsuarios;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dominio.ValueObject
{
    [ComplexType]
    public record Telefono : IValidable
    {
        public string Tel { get; private set; }

        public Telefono(string tel)
        {
            Tel = tel?.Trim(); // eliminamos espacios
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Tel))
            {
                throw new UsuarioException("El número de teléfono no puede estar vacío");
            }

            if (Tel.Length != 9 || !Tel.All(char.IsDigit))
            {
                throw new UsuarioException("Ingresa un número de teléfono válido con 9 dígitos");
            }
        }
    }
}
