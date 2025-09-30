using CasosDeUsos.DTOs.DireccionDTO;
using CasosDeUsos.DTOs.MaquinariaDTO;
using CasosDeUsos.DTOs.PublicacionVentaDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapper.MappersDePublicacionVenta
{
    public class MapperPublicacionVenta
    {
        public static Venta PublicacionVentaDTOaEntidad(VentaDTO ventaDTO)
        {

            if (ventaDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            return new Venta(ventaDTO.FechaPublicacionVenta=DateTime.Now, ventaDTO.PrecioVenta,ventaDTO.Titulo,ventaDTO.Foto,
               ventaDTO.UnaMaquina,ventaDTO.ClienteVende,ventaDTO.TipoDePublicacion);
        }
    }
}
    
