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
    public class CUAltaMaquinariaTractor : ICUAltaMaquinariaTractor
    {
        public IRepositorioMaquinariaTractor RepositorioMaquinariaTractor { get; set; }
        public CUAltaMaquinariaTractor(IRepositorioMaquinariaTractor repositorioMaquinariaTractor)
        {
            RepositorioMaquinariaTractor = repositorioMaquinariaTractor;
        }

        public void Ejecutar(TractorDTO tractorDTO)
        {
            Tractor tractor = MapperTractor.TractorDTOoTractor(tractorDTO);
            RepositorioMaquinariaTractor.Add(tractor);
        }
    }
}
