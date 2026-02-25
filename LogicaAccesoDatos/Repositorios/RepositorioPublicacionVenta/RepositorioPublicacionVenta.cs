using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio.IRepositorioPublicacionVenta;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios.RepositorioPublicacionVenta
{
    public class RepositorioPublicacionVenta : IRepositorioPublicacionVenta
    {
        public EmpresaContexto Contexto {  get; set; }
        public RepositorioPublicacionVenta(EmpresaContexto contexto)
        {
            Contexto = contexto;
        }

        public void Add(Publicacion publicacion)
        {
            publicacion.Validar();
            Contexto.publicaciones.Add(publicacion);
            Contexto.SaveChanges();
        }

        public IEnumerable<Venta> FindAllPublicacionesVenta()
        {
            return Contexto.publicaciones
                .OfType<Venta>()
                .Include(v => v.UnaMaquina)                  // Carga la maquinaria
                    .ThenInclude(m => m.Caracteristica)     // Carga la característica
                .Include(v => v.UnaMaquina)                  // Repetir Include para otra propiedad
                    .ThenInclude(m => m.Direccion)          // Carga la dirección
                .ToList();
        }

        public Publicacion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publicacion> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(Publicacion item)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Publicacion item)
        {
            throw new NotImplementedException();
        }

        public Publicacion FindByEmail(string item)
        {
            throw new NotImplementedException();
        }

        public Publicacion FindByEmailConRol(string item)
        {
            throw new NotImplementedException();
        }
    }
}
