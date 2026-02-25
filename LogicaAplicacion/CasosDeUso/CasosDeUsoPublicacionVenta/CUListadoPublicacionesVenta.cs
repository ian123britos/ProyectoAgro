using CasosDeUsos.DTOs.PublicacionVentaDTO;
using CasosDeUsos.InterfacesCasosDeUso.IPublicacionVentaCasosDeUso;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioCaracteristicas;
using Dominio.InterfacesRepositorio.InterfacesRepositorioDireccion;
using Dominio.InterfacesRepositorio.InterfacesRepositorioMaquinarias;
using Dominio.InterfacesRepositorio.IRepositorioPublicacionVenta;
using LogicaAplicacion.Mapper.MappersDePublicacionVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CasosDeUsoPublicacionVenta
{
    public class CUListadoPublicacionesVenta : ICUListadoPublicacionesVenta
    {
        public IRepositorioPublicacionVenta RepoPublicacionesVenta { get; set; }


        public CUListadoPublicacionesVenta(IRepositorioPublicacionVenta repoPublicacionesVenta,IRepositorioCaracteristica repositorioCaracteristica,IRepositorioDireccion repositorioDireccion,IRepositorioMaquinaria repositorioMaquinaria)
        {
            RepoPublicacionesVenta = repoPublicacionesVenta;
        }

        public IEnumerable<ListadoPublicacionesEnVentaDTO> Ejecutar()
        {
         
            IEnumerable<Venta> ListadoDePublicacionesEnVenta = RepoPublicacionesVenta.FindAllPublicacionesVenta();
            return MapperPublicacionVenta.MapToListadoPublicacionesVentasDTO(ListadoDePublicacionesEnVenta);
        }

       
    }
}
