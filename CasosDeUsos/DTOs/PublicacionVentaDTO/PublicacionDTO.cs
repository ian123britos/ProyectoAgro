using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.DTOs.PublicacionVentaDTO
{
    public class PublicacionDTO
    {

        public string Titulo { get; set; }
        public string Foto { get; set; }
        public Maquinaria UnaMaquina { get; set; }
        public Cliente ClienteVende { get; set; }
        public TipoDePublicacion TipoDePublicacion { get; set; }

    }
}
