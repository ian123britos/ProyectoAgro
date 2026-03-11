using CasosDeUsos.DTOs.PublicacionVentaDTO;
using CasosDeUsos.InterfacesCasosDeUso.IPublicacionVentaCasosDeUso;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.IRepositorioPublicacionVenta;
using LogicaAplicacion.Mapper.MappersDePublicacionVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CasosDeUsoPublicacionVenta
{
    public class CUBuscarPublicacionEnVenta : ICUBuscarPublicacionEnVenta
    {
        public IRepositorioPublicacionVenta RepoPublicacionVenta {  get; set; }

        public CUBuscarPublicacionEnVenta(IRepositorioPublicacionVenta repoPublicacionVenta)
        {
            RepoPublicacionVenta = repoPublicacionVenta;
        }

        public DetallePublicacionEnVentaDTO Ejecutar(int id)
        {
            Venta ventaBuscada = RepoPublicacionVenta.FindById(id);

            if (ventaBuscada == null)
                throw new Exception("No existe la publicación de venta");

            return MapperPublicacionVenta.MapToDetallePublicacionVentaDTO(ventaBuscada);
        }
    }
}
