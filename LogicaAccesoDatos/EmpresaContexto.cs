using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
namespace LogicaAccesoDatos
{
    public class EmpresaContexto:DbContext
    {
        public DbSet<Caracteristica> caracteristicas {  get; set; }
        public DbSet<Direccion> direcciones { get; set; }
        public DbSet<Tractor> tractores { get; set; }
        public DbSet<Sembradora> sembradoras { get; set; }
        public DbSet<Fertilizadora> fertilizadoras { get; set; }

        public EmpresaContexto(DbContextOptions options) : base(options) { }


    }
}
