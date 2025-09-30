using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasosDeUsos.DTOs.PublicacionVentaDTO;
using CasosDeUsos.InterfacesCasosDeUso.IPublicacionVenta;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.IRepositorioPublicacionVenta;
using LogicaAplicacion.Mapper.MappersDePublicacionVenta;


namespace LogicaAplicacion.CasosDeUso.CasosDeUsoPublicacionVenta
{
    public class CUAltaPublicacionVenta : ICUAltaPublicacionVenta
    {
        public IRepositorioPublicacionVenta RepositorioPublicacionVenta { get; set; }
        public CUAltaPublicacionVenta(IRepositorioPublicacionVenta repositorioPublicacionVenta)
        {
            RepositorioPublicacionVenta = repositorioPublicacionVenta;
        }

        public void Ejecutar(VentaDTO ventaDTO)
        {
           Venta venta = MapperPublicacionVenta.PublicacionVentaDTOaEntidad(ventaDTO);
            RepositorioPublicacionVenta.Add(venta);
        }
    }
}
