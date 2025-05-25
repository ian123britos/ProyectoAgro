using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Maquinaria
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime Anio { get; set; }
        public int PrecioVenta { get; set; }
        public string Pais {  get; set; }
        public string Ciudad {  get; set; }
        public string Barrio { get; set; }
        public int HorasDeUso   { get; set; }
        public bool EsUsado { get; set; }
        public TipoDireccion TipoDireccion { get; set; }
        public bool UnicoDuenio { get; set; }
        public TipoCombustible TipoCombustible { get; set; }
        public string OtrasCaracteristicas { get; set; }
        

        public Maquinaria() 
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Maquinaria(string categoria, string marca,string modelo, DateTime anio, int precioVenta,string pais, string ciudad,string barrio,int horasDeUso,
            bool esUsado,TipoDireccion tipoDireccion,bool unicoDuenio,TipoCombustible tipoCombustible,string otrasCaracteristicas)
        {

            this.Categoria = categoria;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Anio = anio;
            this.PrecioVenta = precioVenta;
            this.Pais = pais;
            this.Ciudad = ciudad;
            this.Barrio = barrio;
            this.HorasDeUso = horasDeUso;
            this.EsUsado = esUsado;
            this.TipoDireccion = tipoDireccion;
            this.UnicoDuenio = unicoDuenio;
            this.TipoCombustible = tipoCombustible;
            this.OtrasCaracteristicas = otrasCaracteristicas;

        }

        public abstract string TipoVechiculo();

           
    }
}
