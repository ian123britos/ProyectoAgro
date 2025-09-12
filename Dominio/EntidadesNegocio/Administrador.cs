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

        public Administrador() { }
        public Administrador(string apodo, string email, string password, Rol rol) : base(email, password, rol)
        {
            Apodo = apodo;
            Validar();
        }

        public  void Validar()
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
