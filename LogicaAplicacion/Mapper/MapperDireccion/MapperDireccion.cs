using CasosDeUsos.DTOs.DireccionDTO;
using CasosDeUsos.DTOs.MaquinariaDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapper.MapperDireccion
{
    public class MapperDireccion
    {
        //Para mappear los datos de las clases con las clasesDTO en el Alta
        public static Direccion DireccionDTOoDireccion(DireccionDTO direccionDTO)
        {
            if (direccionDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            return new Direccion(direccionDTO.Pais, direccionDTO.Ciudad, direccionDTO.Barrio);
        }
    }
}
