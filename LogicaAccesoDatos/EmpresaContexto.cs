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


        //-----------------------------------------------------
        public DbSet<Caracteristica> caracteristicas {  get; set; }
        public DbSet<Direccion> direcciones { get; set; }

        //-----------------------------------------------------------
        public DbSet<Maquinaria> maquinarias { get; set; }
        public DbSet<Tractor> tractores { get; set; }
        public DbSet<Sembradora> sembradoras { get; set; }
        public DbSet<Fertilizadora> fertilizadoras { get; set; }
        public DbSet<Cosechadora> cosechadoras { get; set; }
        public DbSet<CargadoraPala> cargadorasPala { get; set; }

        //--------------------------------------------------------------
        public DbSet<Publicacion> publicaciones { get; set; }
        public DbSet<Venta> ventas { get; set; }

        //-------------------------------------------------------
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Administrador> administradores { get; set; }
        //-------------------------------------------------------

        public DbSet<Compra> compras { get; set; }

        public EmpresaContexto(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación Compra - Cliente
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.ClienteCompra)
                .WithMany() // o .WithMany(u => u.Compras) si tenés la colección
                .HasForeignKey(c => c.ClienteCompraId)
                .OnDelete(DeleteBehavior.Restrict); // 🔑 corta la cascada

            // Relación Compra - Publicacion
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.PublicacionComprada)
                .WithMany() // o .WithMany(p => p.Compras) si lo tenés
                .HasForeignKey(c => c.PublicacionCompradaId)
                .OnDelete(DeleteBehavior.Cascade); // ✅ cascada lógica
        }






    }
}
    