using Dominio.Interfaces;
using ExcepcionesPropias;
using ExcepcionesPropias.ExceptionCaracteristicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Caracteristica : IValidable
    {
        public int Id { get; private set; }

        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public bool EsUsado { get; set; }
        public bool UnicoDuenio { get; set; }
        public string TipoDeCombustible { get; set; }
        public string TipoDeDireccion { get; set; }

        private Caracteristica()
        {

        }
        public Caracteristica(string categoria, string marca, string modelo, int anio, bool esUsado, bool unicoDuenio, string tipoDeCombustible, string tipoDeDireccion)
        {
            Categoria = categoria;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            EsUsado = esUsado;
            UnicoDuenio = unicoDuenio;
            TipoDeCombustible = tipoDeCombustible;
            TipoDeDireccion = tipoDeDireccion;
            Validar();
        }
        public void Validar()
        {
            ValidarCategoria();
            ValidarMarca();
            ValidarModelo();
            ValidarAnio();
            ValidarTipoDeCombustible();
            ValidarTipoDeDireccion();

        }

        private void ValidarTipoDeDireccion()
        {
            if(string.IsNullOrEmpty(TipoDeDireccion))
            {
                throw new CaracteristicaException("El tipo de direccion no puede ser vacio (Manual,Automático,etc)");
            }
        }

        private void ValidarTipoDeCombustible()
        {
            if (string.IsNullOrEmpty(TipoDeCombustible))
            {
                throw new CaracteristicaException("El tipo de combustible no puede ser vacio (Diesel,Nafta,etc)");
            }
        }

        private void ValidarAnio()
        {

            if (Anio < 1800 || Anio > DateTime.Now.Year)
            {
                throw new CaracteristicaException($"El año debe tener 4 dígitos y no puede ser mayor a {DateTime.Now.Year}.");

            }
        }

        private void ValidarModelo()
        {
            if (string.IsNullOrEmpty(Modelo))
            {
                throw new CaracteristicaException("El campo de modelo de maquina no puede ser vacio ");
            }

        }

        private void ValidarMarca()
        {
            if (string.IsNullOrEmpty(Marca))
            {
                throw new CaracteristicaException("El campo de marca no puede ser vacio");
            }
        }

        private void ValidarCategoria()
        {
            if (string.IsNullOrEmpty(Categoria))
            {
                throw new CaracteristicaException("El campo categoría no puede ser vacio");
            }
        }





    }
}
