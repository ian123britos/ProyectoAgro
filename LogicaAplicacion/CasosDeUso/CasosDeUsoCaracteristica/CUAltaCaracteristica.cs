using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasosDeUsos.DTOs.CaracteristicaDTOs;
using CasosDeUsos.InterfacesCasosDeUso.ICaracteristicaCasoDeUso;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioCaracteristicas;
using LogicaAplicacion.Mapper.MapperCaracteristicas;

namespace LogicaAplicacion.CasosDeUso.CasosDeUsoCaracteristica
{
    public class CUAltaCaracteristica : ICUAltaCaracteristica
    {
        public IRepositorioCaracteristica RepositorioCaracteristica { get; set; }

        public CUAltaCaracteristica(IRepositorioCaracteristica repositorioCaracteristica)
        {
            RepositorioCaracteristica = repositorioCaracteristica;
        }

        //Para el alta de caracteristicas:
        public void Ejecutar(CaracteristicaDTO caracteristicaDTO)
        {
            Caracteristica caracteristica = MapperCaracteristica.CaracteristicaDTOoCaracteristica(caracteristicaDTO);
            RepositorioCaracteristica.Add(caracteristica);
        }
    }
}
