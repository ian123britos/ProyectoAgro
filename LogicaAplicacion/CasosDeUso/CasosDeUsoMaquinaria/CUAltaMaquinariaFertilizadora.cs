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
    public class CUAltaMaquinariaFertilizadora:ICUAltaMaquinariaFertilizadora
    {
        //Inyeccion de dependencia:
        public IRepositorioMaquinaria RepositorioMaquinaria { get; set; }

        //necesito los objetos que guarda mi maquinaria:
        /*prueba:*/public IRepositorioCaracteristica RepositorioCaracteristica { get; set; }

        public IRepositorioDireccion RepositorioDireccion { get; set; }
       
        public CUAltaMaquinariaFertilizadora(IRepositorioMaquinaria repositorioMaquinaria,/*PRUEBA:*/IRepositorioCaracteristica repositorioCaracteristica,IRepositorioDireccion repositorioDireccion)
        {
            RepositorioMaquinaria = repositorioMaquinaria;
           /* PRUEBA:*/ RepositorioCaracteristica = repositorioCaracteristica;
            RepositorioDireccion = repositorioDireccion;
        }

        public void Ejecutar(FertilizadoraDTO fertilizadoraDTO)
        {
            /*prueba:*/ Caracteristica caracteristica = RepositorioCaracteristica.FindById(fertilizadoraDTO.CaracteristicaId);

            Direccion direccion = RepositorioDireccion.FindById(fertilizadoraDTO.DireccionId);

            if (caracteristica != null)
            {

                Fertilizadora fertilizadora = MapperMaquinariaFertilizadora.MaquinariaFertilizadoraDTOaEntidad(fertilizadoraDTO,/*prueba:*/caracteristica,direccion);
                RepositorioMaquinaria.Add(fertilizadora);
            }
        }
    }
}
