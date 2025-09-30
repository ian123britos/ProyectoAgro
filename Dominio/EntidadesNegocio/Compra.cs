using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Compra
    {
        public int Id { get; private set; }
        public DateTime FechaCompra { get; set; }


        // 🔹 FK explícita
        public int ClienteCompraId { get; set; }
        public Cliente ClienteCompra { get; set; }

        // 🔹 FK explícita
        public int PublicacionCompradaId { get; set; }
        public Publicacion PublicacionComprada { get; set; }
    


        private Compra()
        {

        }
        public Compra(DateTime fechaCompra, Cliente clienteCompra, Publicacion publicacionComprada)
        {
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
