using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObject
{
    public class Email : IValidable
    {
        public string EmailUsr { get; private set; }

        public Email(string emailUsr)
        {
            EmailUsr = emailUsr;
            Validar();
        }
        public void Validar()
        {
            if (!string.IsNullOrEmpty(EmailUsr))
            {
                bool tieneArroba = false;
                for (int i = 0; i < EmailUsr.Length; i++)
                {
                    if (EmailUsr[i] == '@')
                    {
                        tieneArroba = true;
                    }
                }

                if (!tieneArroba)
                {
                    throw new Exception("Direccion de Email no valida falta el @");
                }
            }
            else
            {
                throw new Exception("El Email no puede ser vacio");
            }
        }


    }
}
