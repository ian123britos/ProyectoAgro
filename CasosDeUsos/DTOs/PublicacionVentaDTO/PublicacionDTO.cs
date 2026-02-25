
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasosDeUsos.DTOs.MaquinariaDTO;
using Dominio.EntidadesNegocio;


namespace CasosDeUsos.DTOs.PublicacionVentaDTO
{
    // DTO
    public class PublicacionDTO
    {
        public int Id {  get; set; }
        public string Titulo { get; set; }
        public string Foto { get; set; }
        public int MaquinariaId { get; set; }
        public int ClienteVendeId { get; set; }

        public TipoDePublicacion TipoDePublicacion { get; set; }
    }
}
