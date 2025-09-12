using Dominio.Interfaces;
using Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Cliente : Usuario,IValidable
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Telefono Telefono { get; set; }

        public Cliente()
        {
        }
        public Cliente(string nombre, string apellido, int telefono, string email, string password, Rol rol) : base(email, password, rol)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = new Telefono(telefono);
            Validar();
        }

        public void Validar()
        {
            
            ValidarApellido();
            ValidarNombre();

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
