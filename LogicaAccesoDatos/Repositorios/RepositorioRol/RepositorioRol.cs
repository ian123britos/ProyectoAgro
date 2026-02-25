using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.IRepositorioRol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios.RepositorioRol
{
    public class RepositorioRol : IRepositorioRol
    {
        public EmpresaContexto Contexto { get; set; }
        public RepositorioRol(EmpresaContexto contexto)
        {
            Contexto = contexto;
        }

        public void Add(Rol rol)
        {
            Contexto.Rol.Add(rol);
            Contexto.SaveChanges();
            
        }


        public Rol FindById(int id)
        {
            return Contexto.Rol.Find(id);

        }

        public void Delete(Rol item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> FindAll()
        {
            throw new NotImplementedException();
        }

        public Rol FindByEmail(string item)
        {
            throw new NotImplementedException();
        }


        public void Update(int id, Rol item)
        {
            throw new NotImplementedException();
        }

        public Rol FindByEmailConRol(string item)
        {
            throw new NotImplementedException();
        }
    }
}
