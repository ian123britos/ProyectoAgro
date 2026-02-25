using CasosDeUsos.DTOs.ClienteDTO;
using CasosDeUsos.InterfacesCasosDeUso.IUsuarioCasosDeUso;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.IRepositorioUsuario;
using ExcepcionesPropias.ExceptionUsuarios;
using LogicaAplicacion.Mapper.MapperUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CasosDeUsoUsuario
{
    public class CUBuscarUsuario:ICUBuscarUsuario
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public CUBuscarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public DetalleUsuarioDTO Ejecutar(int id)
        {
            Cliente cliente = RepositorioUsuario.FindByIdCliente(id);
            if (cliente != null)
            {
                return MapperUsuario.DetalleClienteDTOoTODetalleClienteEntidad(cliente);
            }
            else
            {
                throw new UsuarioException("Id incorrecto");
            }

        }
    }
}
