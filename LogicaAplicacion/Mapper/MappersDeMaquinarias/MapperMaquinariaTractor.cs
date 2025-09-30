using CasosDeUsos.DTOs.MaquinariaDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LogicaAplicacion.Mapper.MappersDeMaquinarias
{

    public class MapperMaquinariaTractor
    {
        public static Tractor MaquinariaTractorDTOaEntidad(TractorDTO tractorDTO,Caracteristica caracteristica,Direccion direccion)
        {
            if (tractorDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            return new Tractor(tractorDTO.TieneCabina,direccion,caracteristica,tractorDTO.OtrasCaracteristicas);
            
        }
    }

}



