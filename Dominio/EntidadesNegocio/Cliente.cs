using Dominio.Interfaces;
using Dominio.ValueObject;
using ExcepcionesPropias;
using ExcepcionesPropias.ExceptionUsuarios;
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

        public Cliente() : base()
        {
        }
        public Cliente(string nombre, string apellido, string telefono, string email, string password) : base(email, password)
        {
            
            Telefono = new Telefono(telefono);
            Nombre = nombre;
            Apellido = apellido;

            // Asignar rol fijo, cliente es rol cliente harcodeo
            this.Rol = new Rol("Cliente");

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
                throw new UsuarioException("El apellido no puede ser vacio");
            }
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new UsuarioException("El nombre no puede ser vacio");
            }
        }


    }
}
