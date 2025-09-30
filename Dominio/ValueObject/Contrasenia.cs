using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObject
{
    [ComplexType]
    public record Contrasenia : IValidable
    {
       
        public string Pass { get; private set; }

        public Contrasenia(string pass)
        {
            Pass = pass;
            Validar();

        }
        public void Validar()
        {

            bool tieneNumero = false;
            if (string.IsNullOrEmpty(Pass))
            {
                throw new Exception("La contraseña no puede ser vacía");
            }
            else
            {
                if (Pass.Length < 8)
                {

                    throw new Exception("El largo de la contraseña debe de ser mayor a 8 caracteres");
                }
                else
                {
                    int i = 0;
                    while (i < Pass.Length)
                    {

                        if (Pass[i] >= 48 && Pass[i] <= 57)//tiene numero?
                        {
                            tieneNumero = true;
                        }
                        i++;
                    }
                    if (!tieneNumero)
                    {
                        throw new Exception("La contraseña debe de tener por lo menos un numero ");

                    }

                }
            }


        }
    }
}
