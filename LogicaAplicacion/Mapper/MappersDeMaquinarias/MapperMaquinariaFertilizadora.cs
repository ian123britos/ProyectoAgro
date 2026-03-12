using CasosDeUsos.DTOs.MaquinariaDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapper.MappersDeMaquinarias
{
    public class MapperMaquinariaFertilizadora
    {
        public static Fertilizadora MaquinariaFertilizadoraDTOaEntidad(FertilizadoraDTO fertilizadoraDTO,Caracteristica caracteristica,Direccion direccion)
        {
            if (fertilizadoraDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            return new Fertilizadora(fertilizadoraDTO.MarcaMotor, fertilizadoraDTO.Potencia, fertilizadoraDTO.DobleTraccion,
                direccion,caracteristica, fertilizadoraDTO.OtrasCaracteristicas);
        }
    }
}
