using Dominio.Interfaces;
using Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public abstract class Usuario
    {
        public int Id { get; private set; }
        public static int UltimoId;
        public Email Email { get; set; }
        public Contrasenia Contrasenia { get; set; }
        public Rol Rol { get; set; }


        public Usuario()
        {
            Id = UltimoId++;

        }

        public Usuario(string email, string password, Rol rol)
        {
            Id = UltimoId++;
            Email = new Email(email);
            Contrasenia = new Contrasenia(password);
            Rol = rol;
            
        }
       
        public override bool Equals(object? obj)
        {
            Usuario usuario = (Usuario)obj;
            return usuario.Email == Email;
        }
    }
}
