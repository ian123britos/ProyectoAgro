using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra : Publicacion
    {
        public DateTime FechaCompra {  get; set; }

        public Compra(DateTime fechaCompra, string titulo, string foto, Maquinaria unaMaquina, Cliente clienteAccionar, TipoDePublicacion tipoDePublicacion)
            : base(titulo,foto,unaMaquina,clienteAccionar,tipoDePublicacion)
        {
            FechaCompra = fechaCompra;
        }

        public override string ToString()
        {
            string dato = $"Usted acaba de confirar la compra de {UnaMaquina.TipoVechiculo()}\n" +
                $"fecha de compra: {FechaCompra}\n" +
                $" la maquina a vender es: {UnaMaquina}";
            return dato;
        }

        public override double CalcularPrecioFinal(double precio)
        {
            throw new NotImplementedException();
        }
    }
}
