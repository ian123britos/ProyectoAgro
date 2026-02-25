using Dominio.Interfaces;
using ExcepcionesPropias;
using ExcepcionesPropias.ExceptionUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObject
{
    [ComplexType]
    public record Email : IValidable
    {
        public string EmailUsr { get;  set; }

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
                    throw new UsuarioException("Direccion de Email no valida falta el @");
                }
            }
            else
            {
                throw new UsuarioException("El Email no puede ser vacio");
            }
        }


    }
}
