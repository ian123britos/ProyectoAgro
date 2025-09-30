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
    public class CUAltaMaquinariaTractor : ICUAltaMaquinariaTractor
    {
        public IRepositorioMaquinaria RepositorioMaquinaria { get; set; }
        public IRepositorioCaracteristica RepositorioCaracteristica { get; set; }
        public IRepositorioDireccion RepositorioDireccion { get; set; }
        public CUAltaMaquinariaTractor(IRepositorioMaquinaria repositorioMaquinaria, IRepositorioCaracteristica repositorioCaracteristica, IRepositorioDireccion repositorioDireccion)
        {

            RepositorioMaquinaria = repositorioMaquinaria;
            RepositorioCaracteristica = repositorioCaracteristica;
            RepositorioDireccion = repositorioDireccion;
        }

        public void Ejecutar(TractorDTO tractorDTO)
        {
            // Recupera las entidades existentes de Característica y Dirección usando los IDs
            // que fueron guardados previamente en el DTO (provenientes de la Session en el controller).
            // Luego, mapea el TractorDTO a una entidad Tractor y asigna estas entidades recuperadas
            // para que la relación se mantenga al persistir en la base de datos.
            // Finalmente, guarda el Tractor con sus referencias en el repositorio.
            Caracteristica caracteristica = RepositorioCaracteristica.FindById(tractorDTO.CaracteristicaId);
            if(caracteristica == null)
            { throw new Exception("No se encontro la caracteristica seleccionada"); }

            Direccion direccion = RepositorioDireccion.FindById(tractorDTO.DireccionId);
            if(direccion == null) { throw new Exception("No se encontro la direccion seleccionada");}

                Tractor tractor = MapperMaquinariaTractor.MaquinariaTractorDTOaEntidad(tractorDTO,caracteristica,direccion);

                //tractor.Caracteristica = caracteristica;
                //tractor.Direccion = direccion;

                RepositorioMaquinaria.Add(tractor);
        }
    }
}
