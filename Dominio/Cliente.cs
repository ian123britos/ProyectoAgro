using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }

        public Cliente()
        {
        }
        public Cliente(string nombre, string apellido,int telefono,string email, string password,Rol rol) : base( email, password,rol)
        {
             Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
        }

        public override void Validar()
        {
            base.Validar();
            //ValidarTelefono();
            ValidarApellido();
            ValidarNombre();

        }

        private void ValidarTelefono()
        {
            // Convertimos a string por si Telefono es int
            string telefonoStr = Telefono.ToString();

            if (string.IsNullOrWhiteSpace(telefonoStr))
            {
                throw new Exception("El número de teléfono no puede estar vacío");
            }

            if (telefonoStr.Length != 9 || !telefonoStr.All(char.IsDigit))
            {
                throw new Exception("Ingresa un número de teléfono válido con 9 dígitos");
            }
        }

        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("El apellido no puede ser vacio");
            }
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }


    }
}
