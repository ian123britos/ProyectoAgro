using CasosDeUsos.DTOs.MaquinariaDTO;
using CasosDeUsos.InterfacesCasosDeUso.IMaquinariaCasosDeUso;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioMaquinarias;
using LogicaAplicacion.Mapper.MappersDeMaquinarias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CasosDeUsoMaquinaria
{
    public class CUAltaMaquinariaFertilizadora : ICUAltaMaquinariaFertilizadora
    {
        public IRepositorioMaquinariaFertilizadora RepositorioMaquinariaFertilizadora { get; set; }
        public CUAltaMaquinariaFertilizadora(IRepositorioMaquinariaFertilizadora repositorioMaquinariaFertilizadora)
        {
            RepositorioMaquinariaFertilizadora = repositorioMaquinariaFertilizadora;
        }

        public void Ejecutar(FertilizadoraDTO fertilizadoraDTO)
        {
            Fertilizadora fertilizadora = MapperFertilizadora.FertilizadoraDTOoFertilizadora(fertilizadoraDTO);
            RepositorioMaquinariaFertilizadora.Add(fertilizadora);
        }
    }
}
