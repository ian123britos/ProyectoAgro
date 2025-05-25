using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario
    {
        public string NombreUsuario {  get; set; }

        public Cliente(string nombreUsuario, string nombre, string apellido, string email, string password, int telefono) : base(nombre, apellido, email, password, telefono)
        {
            this.NombreUsuario = nombreUsuario;
        }

        public void Validar()
        {
            ValidarNombreUsuario();
        }

        private void ValidarNombreUsuario()
        {
           if(string.IsNullOrEmpty(NombreUsuario))
            {
                throw new Exception("El nombre de usuario no puede ser vacio");
            }
        }
    }
}
