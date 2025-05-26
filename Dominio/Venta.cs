using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta : Publicacion
    {
        public DateTime FechaPublicacionVenta { get; set; }
        public double PrecioVenta { get; set; }

        public Venta() { }
        public Venta(DateTime fechaPublicacionVenta,double precioVenta, string titulo, string foto, Maquinaria unaMaquina, Cliente clienteVende, TipoDePublicacion tipoDePublicacion) 
            : base(titulo,foto,unaMaquina,clienteVende,tipoDePublicacion)
        {
            FechaPublicacionVenta = fechaPublicacionVenta;
            PrecioVenta = precioVenta;


        }

        public override string ToString()
        {
            string dato = $"{Titulo}\n" +
                $"la fecha de publicacion es {FechaPublicacionVenta}\n" +
                $"la categoria del vechiculo es: {UnaMaquina.Caracteristica.Categoria}\n" +
                $"su modelo es: {UnaMaquina.Caracteristica.Modelo}\n" +
                $"la marca es: {UnaMaquina.Caracteristica.Marca}\n" +
                $"año de fabricacion: {UnaMaquina.Caracteristica.Anio}\n" +
                $"la maquina a vender es: {UnaMaquina.TipoVechiculo()}\n" +
                $"su precio de venta es: {PrecioVenta}";
            return dato;
        }

        public override double CalcularPrecioFinal(double precio)
        {
            return PrecioVenta;
        }
    }
}
