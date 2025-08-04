using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Caracteristica : IValidable
    {
        public int IdCaracteristica { get; set; }
        public static int UltimoIdCaracteristica { get; set; } = 1;
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public bool EsUsado { get; set; }
        public bool UnicoDuenio { get; set; }
        public TipoCombustible TipoDeCombustible { get; set; }
        public TipoDireccion TipoDeDireccion { get; set; }

        public Caracteristica()
        {
            IdCaracteristica = UltimoIdCaracteristica++;
        }
        public Caracteristica(string categoria, string marca, string modelo, int anio, bool esUsado, bool unicoDuenio, TipoCombustible tipoDeCombustible, TipoDireccion tipoDeDireccion)
        {
            IdCaracteristica = UltimoIdCaracteristica++;
            Categoria = categoria;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            EsUsado = esUsado;
            UnicoDuenio = unicoDuenio;
            TipoDeCombustible = tipoDeCombustible;
            TipoDeDireccion = tipoDeDireccion;
        }
        public void Validar()
        {
            ValidarCategoria();
            ValidarMarca();
            ValidarModelo();
            ValidarAnio();

        }


        private void ValidarAnio()
        {

            if (Anio < 1800 || Anio > DateTime.Now.Year)
            {
                throw new Exception($"El año debe tener 4 dígitos y no puede ser mayor a {DateTime.Now.Year}.");

            }
        }

        private void ValidarModelo()
        {
            if (string.IsNullOrEmpty(Modelo))
            {
                throw new Exception("El campo de modelo de maquina no puede ser vacio ");
            }

        }

        private void ValidarMarca()
        {
            if (string.IsNullOrEmpty(Marca))
            {
                throw new Exception("El campo de marca no puede ser vacio");
            }
        }

        private void ValidarCategoria()
        {
            if (string.IsNullOrEmpty(Categoria))
            {
                throw new Exception("El campo categoría no puede ser vacio");
            }
        }





    }
}
