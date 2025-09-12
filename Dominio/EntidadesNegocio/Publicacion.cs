using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public abstract class Publicacion : IValidable
    {
        public int IdPublicacion { get; private set; }
        public static int UltimoIdPublicacion;
        public string Titulo { get; set; }
        public string Foto { get; set; }
        public Maquinaria UnaMaquina { get; set; }
        public Cliente ClienteVende { get; set; }
        public TipoDePublicacion TipoDePublicacion { get; set; }


        public Publicacion()
        {
            IdPublicacion = UltimoIdPublicacion++;

        }
        public Publicacion(string titulo, string foto, Maquinaria unaMaquina, Cliente clienteVende, TipoDePublicacion tipoDePublicacion)
        {
            IdPublicacion = UltimoIdPublicacion++;
            Titulo = titulo;
            Foto = foto;
            UnaMaquina = unaMaquina;
            ClienteVende = clienteVende;
            TipoDePublicacion = tipoDePublicacion;
            Validar();
        }

        public virtual void Validar()
        {
            ValidarTitulo();


        }

        private void ValidarTitulo()
        {
            if (string.IsNullOrEmpty(Titulo))
            {
                throw new Exception("El titulo no puede ser vacio");
            }
        }






    }
}
