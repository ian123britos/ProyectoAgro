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
        public static Fertilizadora MaquinariaFertilizadoraDTOaEntidad(FertilizadoraDTO fertilizadoraDTO,/*prueba*/Caracteristica caracteristica)
        {
            if (fertilizadoraDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            return new Fertilizadora(fertilizadoraDTO.MarcaMotor, fertilizadoraDTO.Potencia, fertilizadoraDTO.DobleTraccion,
                fertilizadoraDTO.Direccion, /*prueba*/caracteristica, fertilizadoraDTO.OtrasCaracteristicas);
        }
    }
}
