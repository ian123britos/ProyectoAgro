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

        public Cliente(string nombre, string apellido,int telefono,string email, string password) : base( email, password)
        {
             Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
        }

        public override void Validar()
        {
            base.Validar();
            ValidarTelefono();
            ValidarApellido();
            ValidarNombre();

        }

        private void ValidarTelefono()
        {

            if (Telefono != 9)
            {
                throw new Exception("Ingresa un numero de telefono correcto");
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
