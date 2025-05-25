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

        public Venta(DateTime fechaPublicacionVenta, string titulo, string foto, Maquinaria unaMaquina, Cliente clienteAccionar, TipoDePublicacion tipoDePublicacion) 
            : base(titulo,foto,unaMaquina,clienteAccionar,tipoDePublicacion)
        {
            FechaPublicacionVenta = fechaPublicacionVenta;

        }

        public override string ToString()
        {
            string dato = $"{Titulo}\n" +
                $"la fecha de publicacion es {FechaPublicacionVenta}\n" +
                $"la categoria del vechiculo es: {UnaMaquina.Categoria}\n" +
                $"su modelo es: {UnaMaquina.Modelo}\n" +
                $"la marca es: {UnaMaquina.Marca}\n" +
                $"año de fabricacion: {UnaMaquina.Anio}\n" +
                $"la maquina a vender es: {UnaMaquina.TipoVechiculo()}\n" +
                $"su precio de venta es: {UnaMaquina.PrecioVenta}";
            return dato;
        }

        public override double CalcularPrecioFinal(double precio)
        {
            throw new NotImplementedException();
        }
    }
}
