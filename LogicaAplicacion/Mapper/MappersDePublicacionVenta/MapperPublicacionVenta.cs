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
            public static Venta PublicacionVentaDTOaEntidad(VentaDTO ventaDTO, Maquinaria maquinaria,Cliente cliente)
            {
                if (ventaDTO == null)
                    throw new ArgumentNullException("Datos incorrectos");

                if (maquinaria == null)
                    throw new ArgumentNullException("No se proporcionó maquinaria válida");

            if (cliente == null)
                throw new ArgumentNullException("No se proporcionó maquinaria válida");


            //// Validar precio antes de crear la entidad
            //if (ventaDTO.PrecioVenta <= 0)
            //    throw new Exception("El precio de venta debe ser mayor a 0");

            // Asignar fecha de publicación actual
            ventaDTO.FechaPublicacionVenta = DateTime.Now;

            // Crear la entidad Venta con todos los datos correctos
            return new Venta(
                ventaDTO.FechaPublicacionVenta,
                ventaDTO.PrecioVenta,
                ventaDTO.Titulo,
                ventaDTO.Foto,
                maquinaria,
                cliente,
                ventaDTO.TipoDePublicacion
            );
            }
        public static IEnumerable<ListadoPublicacionesEnVentaDTO> MapToListadoPublicacionesVentasDTO(IEnumerable<Venta> ventas)
        {
            return ventas.Select(v => new ListadoPublicacionesEnVentaDTO
            {
                Id = v.Id,
                Titulo = v.Titulo,

                CaracteristicaId = v.UnaMaquina.Caracteristica.Id,
                Marca = v.UnaMaquina.Caracteristica.Marca,
                Modelo = v.UnaMaquina.Caracteristica.Modelo,
                Anio = v.UnaMaquina.Caracteristica.Anio,

                DireccionId = v.UnaMaquina.Direccion.Id,
                Ciudad = v.UnaMaquina.Direccion.Ciudad,
                Pais = v.UnaMaquina.Direccion.Pais
            });
        }
    }

}

    
