using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario:IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public Rol Rol {  get; set; }
        

        public Usuario() 
        {
            Id = UltimoId++;

        }

        public Usuario(string email,string password, Rol rol)
        {
            Id = UltimoId++;
            this.Email = email;
            this.Contrasenia = password;
            Rol = rol;
        }

        public virtual void Validar()
        {

            ValidarEmail();
            ValidarPassword();

        }


        private void ValidarPassword()
        {
            bool tieneNumero = false;
            bool tieneMayuscula = false;
            bool tieneMinuscula = false;
            bool tieneCaracterEspecial = false;
            if (string.IsNullOrEmpty(Contrasenia))
            {
                throw new Exception("La contraseña no puede ser vacía");
            }
            else
            {
                if (Contrasenia.Length < 8)
                {

                    throw new Exception("El largo de la contraseña debe de ser mayor a 8 caracteres");
                }
                else
                {
                    int i = 0;
                    while (i < Contrasenia.Length)
                    {
                        if ((int)Contrasenia[i] >= 65 && (int)Contrasenia[i] <= 90)//tiene mayuscula?
                        {
                            tieneMayuscula = true;
                        }
                        if ((int)Contrasenia[i] >= 97 && (int)Contrasenia[i] <= 122)//tiene minuscula?
                        {
                            tieneMinuscula = true;
                        }
                        if ((int)Contrasenia[i] >= 48 && (int)Contrasenia[i] <= 57)//tiene numero?
                        {
                            tieneNumero = true;
                        }
                        if ((int)Contrasenia[i] >= 33 && (int)Contrasenia[i] <= 47 || (int)Contrasenia[i] >= 58 && (int)Contrasenia[i] <= 64 || (int)Contrasenia[i] >= 91 && (int)Contrasenia[i] <= 96)
                        {
                            tieneCaracterEspecial = true;
                        }
                        i++;
                    }
                    if (!tieneMayuscula || !tieneMinuscula || !tieneNumero || !tieneCaracterEspecial)
                    {
                        throw new Exception("La contraseña debe de tener por lo menos una mayuscula, una minuscula , un numero y un caracter especial");

                    }

                }
            }
        }

        private void ValidarEmail()
        {
            if (!string.IsNullOrEmpty(Email))
            {
                bool tieneArroba = false;
                for (int i = 0; i < Email.Length; i++)
                {
                    if (Email[i] == '@')
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

      

        public override bool Equals(object? obj)
        {
            Usuario usuario = (Usuario) obj;
            return usuario.Email == Email;
        }
    }
}
