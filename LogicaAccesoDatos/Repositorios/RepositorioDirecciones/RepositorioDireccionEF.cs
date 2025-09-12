using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioDireccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios.RepositorioDirecciones
{
    public class RepositorioDireccionEF : IRepositorioDireccion
    {
        public EmpresaContexto Contexto { get; set; }

        public RepositorioDireccionEF(EmpresaContexto contexto)
        {
            Contexto = contexto;
        }

        public void Add(Direccion direccion)
        {
            direccion.Validar();
            Contexto.direcciones.Add(direccion);
            Contexto.SaveChanges();// SaveChanges(), EF genera y ejecuta las sentencias 
                                   //SQL necesarias(INSERT, UPDATE, DELETE) para que la base de datos quede sincronizada con lo que tenés en memoria. :D
        }

        public void Delete(Direccion item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Direccion> FindAll()
        {
            throw new NotImplementedException();
        }

        public Direccion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Direccion item)
        {
            throw new NotImplementedException();
        }
    }
}
