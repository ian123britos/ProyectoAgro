using CasosDeUsos.DTOs.MaquinariaDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapper.MappersDeMaquinarias
{
    public static class MapperMaquinariaSembradora
    {
        public static Sembradora MaquinariaSembradoraDTOaEntidad(SembradoraDTO sembradoraDTO, Caracteristica caracteristica, Direccion direccion)
        {
            if (sembradoraDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            return new Sembradora(sembradoraDTO.TipoDeSembradora, direccion, caracteristica, sembradoraDTO.OtrasCaracteristicas);

        }
    }
}
