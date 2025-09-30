using CasosDeUsos.DTOs.MaquinariaDTO;
using CasosDeUsos.InterfacesCasosDeUso.IMaquinariaCasosDeUso;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioCaracteristicas;
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
       
        public CUAltaMaquinariaFertilizadora(IRepositorioMaquinaria repositorioMaquinaria,/*PRUEBA:*/IRepositorioCaracteristica repositorioCaracteristica)
        {
            RepositorioMaquinaria = repositorioMaquinaria;
           /* PRUEBA:*/ RepositorioCaracteristica = repositorioCaracteristica;
        }

        public void Ejecutar(FertilizadoraDTO fertilizadoraDTO)
        {
            /*prueba:*/ Caracteristica caracteristica = RepositorioCaracteristica.FindById(fertilizadoraDTO.Caracteristica.Id);

            if (caracteristica != null)
            {

                Fertilizadora fertilizadora = MapperMaquinariaFertilizadora.MaquinariaFertilizadoraDTOaEntidad(fertilizadoraDTO,/*prueba:*/caracteristica);
                RepositorioMaquinaria.Add(fertilizadora);
            }
        }
    }
}
