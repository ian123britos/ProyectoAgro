using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario
    {
        public string Apodo {  get; set; }

        public Administrador(string apodo, string nombre, string apellido, string email, string password, int telefono) : base(nombre,apellido,email,password,telefono) 
        {
            this.Apodo = apodo;
        }

        public void Validar()
        {
            ValidarApodo();
        }

        private void ValidarApodo()
        {
            if(string.IsNullOrEmpty(Apodo))
            {
                throw new Exception("Apodo no puede ser vacio");
            }
        }
    }
}
