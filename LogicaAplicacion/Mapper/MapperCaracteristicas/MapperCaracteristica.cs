using CasosDeUsos.DTOs.CaracteristicaDTOs;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapper.MapperCaracteristicas
{
    public class MapperCaracteristica
    {
        public static Caracteristica CaracteristicaDTOoCaracteristica(CaracteristicaDTO caracteristicaDTO)
        {
            return new Caracteristica(caracteristicaDTO.Categoria, caracteristicaDTO.Marca, caracteristicaDTO.Modelo, caracteristicaDTO.Anio, caracteristicaDTO.EsUsado, caracteristicaDTO.UnicoDuenio, caracteristicaDTO.TipoDeCombustible, caracteristicaDTO.TipoDeDireccion);

        }


    }
}
