using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Administrador : Usuario,IValidable
    {
        public string Apodo { get; set; }

        public Administrador() : base() { }
        public Administrador(string apodo, string email, string password) : base(email, password)
        {
            Apodo = apodo;

            this.Rol = new Rol("Admin");
            Validar();
        }

        public void Validar()
        {
          
            ValidarApodo();
        }

        private void ValidarApodo()
        {
            if (string.IsNullOrEmpty(Apodo))
            {
                throw new Exception("Apodo no puede ser vacio");
            }
        }
    }
}
