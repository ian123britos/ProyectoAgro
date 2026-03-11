using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
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

        public Venta FindById(int id)
        {
            return Contexto.publicaciones
                        .OfType<Venta>()
            .Include(p => p.UnaMaquina)
                .ThenInclude(m => m.Caracteristica)
            .Include(p => p.UnaMaquina)
                .ThenInclude(m => m.Direccion)
            .Include(p => p.ClienteVende)
            .Include(p => p.ClienteVende)
            .FirstOrDefault(p => p.Id == id);//TRAEMOS TODO JUNTO PARA NO TENER PROBLEMAS DE CARGA
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

        Publicacion IRepositorio<Publicacion>.FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
