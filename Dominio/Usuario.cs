using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Telefono { get; set; }

        public Usuario() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Usuario(string nombre, string apellido,string email,string password,int telefono)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Password = password;
            this.Telefono = telefono;
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarEmail();
            ValidarPassword();
            ValidarTelefono();
        }

        private void ValidarTelefono()
        {
            bool tieneNueveNumeros = false;
            if(Telefono == 9)
            {
                tieneNueveNumeros = true;
            }
            if(!tieneNueveNumeros)
            {
                throw new Exception("Ingresa un numero de telefono correcto");
            }
        }

        private void ValidarPassword()
        {
            bool largoValido = false;
            bool tieneNumero = false;
            bool tieneMayuscula = false;
            bool tieneMinuscula = false;
            bool tieneCaracterEspecial = false;
            if(Password.Length > 8)
            {
                largoValido = true;
            }

           int i = 0;
            while(i < Password.Length)
            {
                if ((int)Password[i] >= 65 && (int)Password[i] <= 90)//tiene mayuscula?
                {
                    tieneMayuscula = true;
                }
                if ((int)Password[i] >= 97 && (int)Password[i] <= 122)//tiene minuscula?
                {
                    tieneMinuscula = true;
                }
                if ((int)Password[i] >= 48 && (int)Password[i] <= 57)//tiene numero?
                {
                    tieneNumero = true;
                }
                if ((int)Password[i] >= 33 && (int)Password[i] <= 47 || (int)Password[i] >= 58 && (int)Password[i] <= 64 || (int)Password[i] >= 91 && (int)Password[i] <= 96)
                {
                    tieneCaracterEspecial = true;
                }
                i++;
            }
            if(!tieneCaracterEspecial || !tieneMayuscula || !tieneMinuscula || !tieneNumero)
            {
                throw new Exception("La contraseña debe de tener por lo menos una mayuscula, una minuscula , un numero y un caracter especial");
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

        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("El apellido no puede ser vacio");
            }
        }

        private void ValidarNombre()
        {
            if(string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }
    }
}
