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

        public Administrador() { }
        public Administrador(string apodo, string email, string password,Rol rol) : base(email,password,rol) 
        {
            this.Apodo = apodo;
        }

        public override void Validar()
        {
            base.Validar();
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
