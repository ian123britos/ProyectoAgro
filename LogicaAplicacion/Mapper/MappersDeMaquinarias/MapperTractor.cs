using CasosDeUsos.DTOs.MaquinariaDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapper.MappersDeMaquinarias
{
    public class MapperTractor
    {
        public static Tractor TractorDTOoTractor(TractorDTO tractorDTO)
        {
            return new Tractor(tractorDTO.TieneCabina, tractorDTO.Direccion, tractorDTO.Caracteristica,tractorDTO.OtrasCaracteristicas);
        }
    }
}
