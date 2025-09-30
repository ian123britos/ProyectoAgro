using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioCaracteristicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios.RepositorioCaracteristicas
{
    public class RepositorioCaracteristicasEF : IRepositorioCaracteristica
    {
        public EmpresaContexto Contexto { get; set; }
        public RepositorioCaracteristicasEF(EmpresaContexto contexto)
        {
            Contexto = contexto;
        }

        public void Add(Caracteristica caracteristica)
        {
            caracteristica.Validar();
            Contexto.caracteristicas.Add(caracteristica);
            Contexto.SaveChanges();
            // SaveChanges(), EF genera y ejecuta las sentencias 
            //SQL necesarias(INSERT, UPDATE, DELETE) para que la base de datos quede sincronizada con lo que tenés en memoria. :D

        }
        public Caracteristica FindById(int id)
        {
            return Contexto.caracteristicas.Find(id);
        }

        public void Delete(Caracteristica item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Caracteristica> FindAll()
        {
            throw new NotImplementedException();
        }

      

        public void Update(int id, Caracteristica item)
        {
            throw new NotImplementedException();
        }
    }
}
