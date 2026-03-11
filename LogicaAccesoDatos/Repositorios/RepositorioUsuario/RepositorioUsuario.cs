using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using Dominio.InterfacesRepositorio.IRepositorioUsuario;
using ExcepcionesPropias;
using ExcepcionesPropias.ExceptionGenericas;
using ExcepcionesPropias.ExceptionUsuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios.RepositorioUsuario
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public EmpresaContexto Contexto { get; set; }
        public RepositorioUsuario(EmpresaContexto contexto)
        {
            Contexto = contexto;
        }

        public void Add(Usuario usuario)
        {
            Usuario u = FindByEmail(usuario.Email.EmailUsr);
            if(u == null)
            {
                Contexto.usuarios.Add(usuario);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ConflictException("Ya existe un usuario con ese mail, intente con otro");
            }
        }

        public Usuario FindByEmail(string email)
        {
            return Contexto.usuarios
                .Where(u => u.Email.EmailUsr == email)
                .FirstOrDefault();
                
        }

        public bool FindByTelefonoYaExistente(string telefono)
        {
            return Contexto.usuarios
                .OfType<Cliente>()
                .Any(u => u.Telefono.Tel == telefono);
        }

        public Usuario FindByEmailConRol(string email)
        {
            return Contexto.usuarios
                          .Include(u => u.Rol) // carga el objeto Rol relacionado
                          .FirstOrDefault(u => u.Email.EmailUsr == email);
        }

        public Usuario FindByEmailAndPassword(string email, string password)
        {
            return Contexto.usuarios
                .Include(u => u.Rol)
                .Where(u => u.Email.EmailUsr.Equals(email) && u.Contrasenia.Pass.Equals(password))
                .SingleOrDefault();
        }
        public void Delete(Usuario item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Cliente FindByIdCliente(int id)
        {
            return Contexto.usuarios
                .OfType<Cliente>()
                .Include(u => u.Rol)
                .Where(u => u.Id == id).SingleOrDefault();
        }

        

        public void Update(int id, Usuario item)
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
