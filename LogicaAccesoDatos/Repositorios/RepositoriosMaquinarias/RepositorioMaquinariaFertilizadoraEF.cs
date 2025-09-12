using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioMaquinarias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios.RepositoriosMaquinarias
{
    public class RepositorioMaquinariaFertilizadoraEF:IRepositorioMaquinariaFertilizadora
    {
        public EmpresaContexto Contexto { get; set; }
        public RepositorioMaquinariaFertilizadoraEF(EmpresaContexto contexto)
        {
            Contexto = contexto;
        }

        public void Add(Fertilizadora fertilizadora)
        {
            fertilizadora.Validar();    
            Contexto.fertilizadoras.Add(fertilizadora);
            Contexto.SaveChanges(); 
        }

        public Fertilizadora FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fertilizadora> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(Fertilizadora item)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Fertilizadora item)
        {
            throw new NotImplementedException();
        }
    }
}
