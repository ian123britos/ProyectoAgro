using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Compra
    {
        public int IdCompra { get; private set; }
        public static int UltimoIdCompra;
        public DateTime FechaCompra { get; set; }
        public Cliente ClienteCompra { get; set; }
        public Publicacion PublicacionComprada { get; set; }

        public Compra()
        {
            IdCompra = UltimoIdCompra++;

        }
        public Compra(DateTime fechaCompra, Cliente clienteCompra, Publicacion publicacionComprada)
        {
            IdCompra = UltimoIdCompra++;
            FechaCompra = fechaCompra;
            ClienteCompra = clienteCompra;
            PublicacionComprada = publicacionComprada;
        }

        #region metodo para traer el precio de venta
        public double ObtenerPrecioDeVenta()
        {
            if (PublicacionComprada is Venta v)
            {
                return v.PrecioVenta;
            }
            else
            {
                throw new Exception("La publicación comprada no tiene precio");
            }
        }
        #endregion
        //public override string ToString()
        //{

        //    return $"Compra Id: {IdCompra}\n" +
        //           $"Fecha: {FechaCompra}\n" +
        //           $"Cliente: {ClienteCompra.Nombre} ({ClienteCompra.Email})\n" +
        //           $"Artículo comprado: {PublicacionComprada.Titulo} - Precio: {ObtenerPrecioDeVenta()}\n" +
        //           $"¡Disfrute de su compra!";
        //}


    }
}
