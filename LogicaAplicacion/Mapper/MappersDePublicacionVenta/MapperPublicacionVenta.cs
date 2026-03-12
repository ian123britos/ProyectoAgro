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

        //MAPPER DE ALTA DE PUBLICACION
        public static Venta PublicacionVentaDTOaEntidad(VentaDTO ventaDTO, Maquinaria maquinaria, Cliente cliente)
        {
            if (ventaDTO == null)
                throw new ArgumentNullException("Datos incorrectos");

            if (maquinaria == null)
                throw new ArgumentNullException("No se proporcionó maquinaria válida");

            if (cliente == null)
                throw new ArgumentNullException("Debe Iniciar Session para realizar el alta de maquinaria");




            // Crear la entidad Venta con todos los datos correctos
            return new Venta(
                DateTime.Now,
                ventaDTO.PrecioVenta,
                ventaDTO.Titulo,
                ventaDTO.Foto,
                maquinaria,
                cliente,
                ventaDTO.TipoDePublicacion
            );
        }


        //MAPPER PARA LISTADO DE PUBLICACIONES EN VENTAS:
        public static IEnumerable<ListadoPublicacionesEnVentaDTO> MapToListadoPublicacionesVentasDTO(IEnumerable<Venta> ventas)
        {
            return ventas.Select(v => new ListadoPublicacionesEnVentaDTO
            {
                Id = v.Id,
                Titulo = v.Titulo,
                Foto = v.Foto,
                Precio = v.PrecioVenta,

                CaracteristicaId = v.UnaMaquina.Caracteristica.Id,
                Marca = v.UnaMaquina.Caracteristica.Marca,
                Modelo = v.UnaMaquina.Caracteristica.Modelo,
                Anio = v.UnaMaquina.Caracteristica.Anio,

                DireccionId = v.UnaMaquina.Direccion.Id,
                Ciudad = v.UnaMaquina.Direccion.Ciudad,
                Pais = v.UnaMaquina.Direccion.Pais


            });
        }


        //Obtener esa publicacion en venta buscada por el ver detalle
        public static DetallePublicacionEnVentaDTO MapToDetallePublicacionVentaDTO(Venta venta)
        {
            DetallePublicacionEnVentaDTO dto = new DetallePublicacionEnVentaDTO()
            {
                Id = venta.Id,
                Precio = venta.PrecioVenta,
                FechaPublicacionVenta = venta.FechaPublicacionVenta,

                Titulo = venta.Titulo,
                Foto = venta.Foto,

                Categoria = venta.UnaMaquina.Caracteristica.Categoria,
                Marca = venta.UnaMaquina.Caracteristica.Marca,
                Modelo = venta.UnaMaquina.Caracteristica.Modelo,
                Anio = venta.UnaMaquina.Caracteristica.Anio,
                EsUsado = venta.UnaMaquina.Caracteristica.EsUsado,
                UnicoDuenio = venta.UnaMaquina.Caracteristica.UnicoDuenio,
                TipoDeCombustible = venta.UnaMaquina.Caracteristica.TipoDeCombustible,
                TipoDeDireccion = venta.UnaMaquina.Caracteristica.TipoDeDireccion,

                Ciudad = venta.UnaMaquina.Direccion.Ciudad,
                Pais = venta.UnaMaquina.Direccion.Pais,

                NombreVendedor = venta.ClienteVende.Nombre,
                EmailVendedor = venta.ClienteVende.Email.EmailUsr,
                TelefonoVendedor = venta.ClienteVende.Telefono.Tel,

                CaracteristicasFaltantes = venta.UnaMaquina.OtrasCaracteristicas.CaracteristicasFaltantes,

                TipoMaquinaria = venta.UnaMaquina.GetType().Name//TRAIGO EL NOMBRE DE LA MAQUINARIA AL DETALLE POR SU OBJETO
            };

            // --------------------------------
            // ATRIBUTOS SEGÚN TIPO MAQUINARIA
            // --------------------------------

            if (venta.UnaMaquina is Tractor tractor)
            {
                dto.TieneCabina = tractor.TieneCabina;
            }

            if (venta.UnaMaquina is Sembradora sembradora)
            {
                dto.TipoSembradora = sembradora.TipoDeSembradora;
            }

            if (venta.UnaMaquina is Fertilizadora fertilizadora)
            {
                dto.MarcaMotor = fertilizadora.MarcaMotor;
                dto.Potencia = fertilizadora.Potencia;
                dto.DobleTraccion = fertilizadora.DobleTraccion;
            }

            if (venta.UnaMaquina is Cosechadora cosechadora)
            {
                dto.TipoCosechadora = cosechadora.TipoCosechadora;
                dto.CapacidadDeCarga = cosechadora.CapacidadDeCarga;
                dto.EsRuedaDual = cosechadora.EsRuedaDual;
            }

            if (venta.UnaMaquina is CargadoraPala cargadora)
            {
                dto.Cilindro = cargadora.Cilindro;
                dto.MarcaMotorCP = cargadora.MarcaMotor;
            }

            return dto;
        }
    }
}
    
