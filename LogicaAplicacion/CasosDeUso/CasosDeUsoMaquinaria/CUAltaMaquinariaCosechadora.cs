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
     public class CUAltaMaquinariaCosechadora : ICUAltaMaquinariaCosechadora
    {
        public IRepositorioCaracteristica RepositorioCaracteristica { get; set; }
        public IRepositorioDireccion RepositorioDireccion { get; set; }
        public IRepositorioMaquinaria RepositorioMaquinaria { get; set; }

        public CUAltaMaquinariaCosechadora(IRepositorioMaquinaria repositorioMaquinaria,IRepositorioCaracteristica repositorioCaracteristica
            ,IRepositorioDireccion repositorioDireccion)
        {
            RepositorioMaquinaria = repositorioMaquinaria;
            RepositorioCaracteristica = repositorioCaracteristica;
            RepositorioDireccion = repositorioDireccion;
        }
        public void Ejecutar(CosechadoraDTO cosechadoraDTO)
        {

            Caracteristica caracteristica = RepositorioCaracteristica.FindById(cosechadoraDTO.CaracteristicaId);
            if (caracteristica == null)
            { throw new Exception("No se encontro la caracteristica seleccionada"); }

            Direccion direccion = RepositorioDireccion.FindById(cosechadoraDTO.DireccionId);
            if (direccion == null) { throw new Exception("No se encontro la direccion seleccionada"); }

            Cosechadora cosechadora = MapperMaquinariaCosechadora.MaquinariaCosechadoraDTOaEntidad(cosechadoraDTO, caracteristica, direccion);
            RepositorioMaquinaria.Add(cosechadora);

            cosechadoraDTO.Id = cosechadora.Id;
            ;
        }
    }
}
