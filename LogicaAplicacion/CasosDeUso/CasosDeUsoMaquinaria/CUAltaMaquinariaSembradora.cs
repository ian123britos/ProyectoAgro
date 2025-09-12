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
    public class CUAltaMaquinariaSembradora : ICUAltaMaquinariaSembradora
    {
        public IRepositorioMaquinariaSembradora RepositorioMaquinariaSembradora { get; set; }
        public CUAltaMaquinariaSembradora(IRepositorioMaquinariaSembradora repositorioMaquinariaSembradora)
        {
            RepositorioMaquinariaSembradora = repositorioMaquinariaSembradora;
        }

        public void Ejecutar(SembradoraDTO sembradoraDTO)
        {
            Sembradora sembradora = MapperSembradora.SembradoraDTOoSembradora(sembradoraDTO);
            RepositorioMaquinariaSembradora.Add(sembradora);
        }
    }
}
