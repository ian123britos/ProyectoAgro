using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioMaquinarias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios.RepositoriosMaquinarias
{
    public class RepositorioMaquinariaSembradoraEF : IRepositorioMaquinariaSembradora
    {
        public EmpresaContexto Contexto { get; set; }
        public RepositorioMaquinariaSembradoraEF(EmpresaContexto contexto)
        {
            Contexto = contexto;
        }
        public void Add(Sembradora sembradora)
        {
            Contexto.sembradoras.Add(sembradora);
            Contexto.SaveChanges();
        }

        public void Delete(Sembradora item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sembradora> FindAll()
        {
            throw new NotImplementedException();
        }

        public Sembradora FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Sembradora item)
        {
            throw new NotImplementedException();
        }
    }
}
