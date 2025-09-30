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

        public Usuario(string email, string password, Rol rol)
        {
           
            Email = new Email(email);
            Contrasenia = new Contrasenia(password);
            Rol = rol;
            
        }
       
        //public override bool Equals(object? obj)
        //{
        //    Usuario usuario = (Usuario)obj;
        //    return usuario.Email == Email;
        //}

        public bool Equals(Usuario? other)
        {
            return Email == other.Email;
        }
    }
}
