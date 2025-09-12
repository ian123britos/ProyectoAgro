using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioMaquinarias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios.RepositoriosMaquinarias
{
    public class RepositorioMaquinariaTractorEF : IRepositorioMaquinariaTractor
    {
        public EmpresaContexto Contexto { get; set; }
        public RepositorioMaquinariaTractorEF(EmpresaContexto contexto)
        {
            Contexto = contexto;
        }
        public void Add(Tractor tractor)
        {
            Contexto.tractores.Add(tractor);
            Contexto.SaveChanges();
        }

        public void Delete(Tractor item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tractor> FindAll()
        {
            throw new NotImplementedException();
        }

        public Tractor FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Tractor item)
        {
            throw new NotImplementedException();
        }
    }
}
