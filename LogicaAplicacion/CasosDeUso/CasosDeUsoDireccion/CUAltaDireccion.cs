using CasosDeUsos.DTOs.DireccionDTO;
using CasosDeUsos.InterfacesCasosDeUso.IDireccionCasoDeUso;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioDireccion;
using LogicaAplicacion.Mapper.MapperDireccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CasosDeUsoDireccion
{
    public class CUAltaDireccion : ICUAltaDireccion
    {
        public IRepositorioDireccion RepositorioDireccion { get; set; }
        public CUAltaDireccion(IRepositorioDireccion repositorioDireccion)
        {
            RepositorioDireccion = repositorioDireccion;
        }

        //Para el alta de direccion:
        public void Ejecutar(DireccionDTO direccionDTO)
        {
            Direccion direccion = MapperDireccion.DireccionDTOoDireccion(direccionDTO);
            RepositorioDireccion.Add(direccion);
        }
    }
}
