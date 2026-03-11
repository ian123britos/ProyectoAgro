using CasosDeUsos.DTOs.ClienteDTO;
using CasosDeUsos.InterfacesCasosDeUso.IUsuarioCasosDeUso;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.IRepositorioUsuario;
using ExcepcionesPropias;
using ExcepcionesPropias.ExceptionGenericas;
using LogicaAplicacion.Mapper.MapperUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CasosDeUsoUsuario
{
    public class CULoginUsuario:ICULoginUsuario
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }

        public CULoginUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public UsuarioLogueadoDTO Ejecutar(LoginUsuarioDTO loginUsuarioDTO)
        {
            if (loginUsuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            Usuario usuario = RepositorioUsuario.FindByEmailAndPassword(loginUsuarioDTO.Email, loginUsuarioDTO.Contrasenia);

            if (usuario == null)
            {
                throw new NotFoundException("Email o Contraseña incorrectos");
            }

            return MapperUsuario.UsuarioToUsuarioLogeadoDTO(usuario);
        }
    }
}
