using Dominio.Interfaces;
using Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public abstract class Usuario:IEquatable<Usuario>
    {
        public int Id { get; private set; }
        public Email Email { get; set; }
        public Contrasenia Contrasenia { get; set; }
        public Rol Rol { get; set; }


        protected Usuario()
        {
          

        }

        // Constructor solo con email y password
        protected Usuario(string email, string password)
        {
            Email = new Email(email);
            Contrasenia = new Contrasenia(password);
        }

        // Constructor completo opcional
        protected Usuario(string email, string password, Rol rol)
            : this(email, password)
        {
            Rol = rol;
        }


        public bool Equals(Usuario? other)
        {
            return Email.Equals(other.Email);
        }
    }
}
