using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.InterfacesRepositorioMaquinarias;
using Dominio.ValueObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios.RepositoriosMaquinarias
{
    public class RepositorioMaquinaria : IRepositorioMaquinaria
    {
        public EmpresaContexto Contexto { get; set; }
        public RepositorioMaquinaria(EmpresaContexto contexto)
        {
            Contexto = contexto;
        }

        public void Add(Maquinaria maquinaria)
        {
            
            Contexto.maquinarias.Add(maquinaria);
            Contexto.SaveChanges();
        }
        public Maquinaria FindById(int id)
        {
            return Contexto.maquinarias.Find(id);
        }

        //public Maquinaria FindByIdConCaracteristicasyDireccion(int id)
        //{
        //    return Contexto.maquinarias
        //        .Include(m => m.Caracteristica)
        //        .Include(m => m.Direccion)
        //        .FirstOrDefault(m => m.Id == id);

        //}
        public IEnumerable<Maquinaria> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(Maquinaria item)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Maquinaria item)
        {
            throw new NotImplementedException();
        }

        public Maquinaria FindByEmail(string item)
        {
            throw new NotImplementedException();
        }

        public Maquinaria FindByEmailConRol(string item)
        {
            throw new NotImplementedException();
        }
    }
}
