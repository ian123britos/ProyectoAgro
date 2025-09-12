using CasosDeUsos.DTOs.MaquinariaDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapper.MappersDeMaquinarias
{
    public class MapperSembradora
    {
        public static Sembradora SembradoraDTOoSembradora(SembradoraDTO sembradoraDTO)
        {
            return new Sembradora(sembradoraDTO.TipoDeSembradora,sembradoraDTO.Direccion,sembradoraDTO.Caracteristica,sembradoraDTO.OtrasCaracteristicas);
        }
    }
}
