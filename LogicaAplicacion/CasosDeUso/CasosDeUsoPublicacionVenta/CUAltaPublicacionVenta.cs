using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasosDeUsos.DTOs.PublicacionVentaDTO;
using CasosDeUsos.InterfacesCasosDeUso.IPublicacionVenta;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioMaquinarias;
using Dominio.InterfacesRepositorio.IRepositorioPublicacionVenta;
using Dominio.InterfacesRepositorio.IRepositorioUsuario;
using LogicaAplicacion.Mapper.MappersDePublicacionVenta;


namespace LogicaAplicacion.CasosDeUso.CasosDeUsoPublicacionVenta
{
    public class CUAltaPublicacionVenta : ICUAltaPublicacionVenta
    {
        public IRepositorioPublicacionVenta RepositorioPublicacionVenta { get; set; }
        public IRepositorioMaquinaria RepositorioMaquinaria { get; set; }
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public CUAltaPublicacionVenta(IRepositorioPublicacionVenta repositorioPublicacionVenta,IRepositorioMaquinaria repositorioMaquinaria,IRepositorioUsuario repositorioUsuario)
        {

            RepositorioPublicacionVenta = repositorioPublicacionVenta;
            RepositorioMaquinaria = repositorioMaquinaria;
            RepositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(VentaDTO ventaDTO,string email)
        {
            Cliente cliente = (Cliente)RepositorioUsuario.FindByEmail(email);
             
            Maquinaria maquinaria = RepositorioMaquinaria.FindById(ventaDTO.MaquinariaId);
            if(maquinaria == null) { throw new Exception("Maquinaria no encontrada"); }

           Venta venta = MapperPublicacionVenta.PublicacionVentaDTOaEntidad(ventaDTO,maquinaria,cliente);

           RepositorioPublicacionVenta.Add(venta);
        }
    }
}
