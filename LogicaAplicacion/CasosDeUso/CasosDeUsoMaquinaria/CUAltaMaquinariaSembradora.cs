using CasosDeUsos.DTOs.MaquinariaDTO;
using CasosDeUsos.InterfacesCasosDeUso.IMaquinariaCasosDeUso;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioCaracteristicas;
using Dominio.InterfacesRepositorio.InterfacesRepositorioDireccion;
using Dominio.InterfacesRepositorio.InterfacesRepositorioMaquinarias;
using LogicaAplicacion.Mapper.MappersDeMaquinarias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CasosDeUsoMaquinaria
{
    public class CUAltaMaquinariaSembradora:ICUAltaMaquinariaSembradora
    {

        public IRepositorioMaquinaria RepositorioMaquinaria { get; set; }
        public IRepositorioCaracteristica RepositorioCaracteristica { get; set; }
        public IRepositorioDireccion RepositorioDireccion { get; set; }
        public CUAltaMaquinariaSembradora(IRepositorioMaquinaria repositorioMaquinaria, IRepositorioCaracteristica repositorioCaracteristica, IRepositorioDireccion repositorioDireccion)
        {

            RepositorioMaquinaria = repositorioMaquinaria;
            RepositorioCaracteristica = repositorioCaracteristica;
            RepositorioDireccion = repositorioDireccion;
        }

        public void Ejecutar(SembradoraDTO sembradoraDTO)
        {   
            Caracteristica caracteristica = RepositorioCaracteristica.FindById(sembradoraDTO.CaracteristicaId);
            if (caracteristica == null)
            { throw new Exception("No se encontro la caracteristica seleccionada"); }

            Direccion direccion = RepositorioDireccion.FindById(sembradoraDTO.DireccionId);
            if (direccion == null) { throw new Exception("No se encontro la direccion seleccionada"); }

            Sembradora sembradora = MapperMaquinariaSembradora.MaquinariaSembradoraDTOaEntidad(sembradoraDTO, caracteristica, direccion);

            RepositorioMaquinaria.Add(sembradora);

            sembradoraDTO.Id = sembradora.Id;
        }
    }
}
