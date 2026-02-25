using CasosDeUsos.DTOs.ClienteDTO;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapper.MapperUsuario
{
    public class MapperUsuario
    {
        public static DetalleUsuarioDTO DetalleClienteDTOoTODetalleClienteEntidad(Cliente cliente)
        {
            return new DetalleUsuarioDTO()
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Telefono = cliente.Telefono.Tel,
                Email = cliente.Email.EmailUsr,
                TipoRol = cliente.Rol.TipoDeRol
            };
        }
        public static Cliente ClienteDTOaEntidadCliente(AltaClienteDTO altaClienteDTO)
        {
            return new Cliente(altaClienteDTO.Nombre, altaClienteDTO.Apellido, altaClienteDTO.Telefono, altaClienteDTO.Email, altaClienteDTO.Contrasenia);
            //el constructor de Cliente ya asigna automaticamente mi Rol
        }

        public static UsuarioLogueadoDTO UsuarioToUsuarioLogeadoDTO(Usuario usuario)
        {
            return new UsuarioLogueadoDTO()
            {
                Email = usuario.Email.EmailUsr,
                Rol = usuario.Rol

            };
        }
    }
}
