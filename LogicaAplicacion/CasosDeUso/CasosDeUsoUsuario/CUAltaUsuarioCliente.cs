using CasosDeUsos.DTOs.ClienteDTO;
using CasosDeUsos.InterfacesCasosDeUso.IUsuarioCasosDeUso;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.IRepositorioRol;
using Dominio.InterfacesRepositorio.IRepositorioUsuario;
using ExcepcionesPropias.ExceptionGenericas;
using LogicaAplicacion.Mapper.MapperUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CasosDeUsoUsuario
{
    public class CUAltaUsuarioCliente:ICUAltaUsuarioCliente
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public IRepositorioRol RepositorioRol { get; set; }
        public CUAltaUsuarioCliente(IRepositorioUsuario repositorioUsuario, IRepositorioRol repositorioRol)
        {
            RepositorioUsuario = repositorioUsuario;
            RepositorioRol = repositorioRol;
        }

        public int Ejecutar(AltaClienteDTO altaClienteDTO)
        {
            //Rol rol = RepositorioRol.FindById(altaClienteDTO.RolId);
            bool yaExisteEseTelefono = RepositorioUsuario.FindByTelefonoYaExistente(altaClienteDTO.Telefono);
            if(yaExisteEseTelefono)
            {
                throw new ConflictException("Ya existe un usuario con ese numero de telefono");
            }
            Cliente cliente = MapperUsuario.ClienteDTOaEntidadCliente(altaClienteDTO);
            RepositorioUsuario.Add(cliente);

            return altaClienteDTO.Id;
        }

    }
}
