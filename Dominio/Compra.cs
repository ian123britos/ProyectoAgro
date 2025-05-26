using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra 
    {
        public DateTime FechaCompra {  get; set; }
        public Cliente ClienteCompra { get; set; }

        public Compra(DateTime fechaCompra,Cliente clienteCompra)
        {
            FechaCompra = fechaCompra;
            ClienteCompra = clienteCompra;
        }

        public override string ToString()
        {
            string dato = $"fecha de compra: {FechaCompra}\n" +
                $"{ClienteCompra} Disfrute de su compra";
            return dato;
        }

       
    }
}
