using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Caracteristica:IValidable
    {
        public int IdCaracteristica { get; set; }
        public static int UltimoIdCaracteristica { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime Anio { get; set; }
        public bool EsUsado { get; set; }
        public bool UnicoDuenio { get; set; }
        public TipoCombustible TipoDeCombustible { get; set; }
        public TipoDireccion TipoDeDireccion { get; set; }

        public Caracteristica() { 
            IdCaracteristica = UltimoIdCaracteristica++;
        }
        public Caracteristica(string categoria, string marca, string modelo, DateTime anio, bool esUsado, bool unicoDuenio, TipoCombustible tipoDeCombustible, TipoDireccion tipoDeDireccion)
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
            if(string.IsNullOrEmpty(Marca))
            {
                throw new Exception("El campo de marca no puede ser vacio");
            }
        }

        private void ValidarCategoria()
        {
            if(string.IsNullOrEmpty(Categoria))
            {
                throw new Exception("El campo categoría no puede ser vacio");
            }
        }

      



    }
}
