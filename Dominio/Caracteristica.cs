using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Caracteristica
    {
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime Anio { get; set; }
        public int HorasDeUso { get; set; }
        public bool UnicoDuenio { get; set; }
        public TipoCombustible TipoDeCombustible { get; set; }
        public TipoDireccion TipoDeDireccion { get; set; }

        public Caracteristica() { }
        public Caracteristica(string categoria, string marca, string modelo, DateTime anio, int horasDeUso, bool unicoDuenio, TipoCombustible tipoDeCombustible, TipoDireccion tipoDeDireccion)
        {
            Categoria = categoria;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            HorasDeUso = horasDeUso;
            UnicoDuenio = unicoDuenio;
            TipoDeCombustible = tipoDeCombustible;
            TipoDeDireccion = tipoDeDireccion;
        }
        public void Validar()
        {
            ValidarCategoria();
            ValidarMarca();
            ValidarModelo();
            ValidarHorasDeUso();

        }

        private void ValidarHorasDeUso()
        {
            if(HorasDeUso<0)
            {
                throw new Exception("Las horas de uso deben de ser un 0 o mayor");
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
