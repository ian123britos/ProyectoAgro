using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Publicacion
    {
        public int Id {  get; set; }
        public static int UltimoId { get; set; }
        public string Titulo { get; set; }
        public string Foto { get; set; }
        public Maquinaria UnaMaquina { get; set; }
        public Cliente ClienteAccionar { get; set; }
        public TipoDePublicacion TipoDePublicacion { get; set; }

        public Publicacion() 
        {
            Id= UltimoId;
            UltimoId++;
        }
        public Publicacion( string titulo, string foto, Maquinaria unaMaquina, Cliente clienteAccionar,TipoDePublicacion tipoDePublicacion)
        {
            
            Titulo = titulo;
            Foto = foto;
            UnaMaquina = unaMaquina;
            ClienteAccionar = clienteAccionar;
            TipoDePublicacion = tipoDePublicacion;
        }

        public void Validar()
        {
            ValidarTitulo();

        }

        private void ValidarTitulo()
        {
            if(string.IsNullOrEmpty(Titulo))
            {
                throw new Exception("El titulo no puede ser vacio");
            }
        }

        public abstract string ToString();

        public abstract double CalcularPrecioFinal(double precio);
        


    }
}
