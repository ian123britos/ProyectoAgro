using CasosDeUsos.DTOs.MaquinariaDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapper.MappersDeMaquinarias
{
    public class MapperFertilizadora
    {
        public static Fertilizadora FertilizadoraDTOoFertilizadora(FertilizadoraDTO fertilizadoraDTO)
        {
            return new Fertilizadora(fertilizadoraDTO.MarcaMotor,fertilizadoraDTO.Potencia,fertilizadoraDTO.DobleTraccion,fertilizadoraDTO.Direccion,fertilizadoraDTO.Caracteristica,fertilizadoraDTO.OtrasCaracteristicas) 
        }
    }
}
