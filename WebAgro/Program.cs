using CasosDeUsos.InterfacesCasosDeUso.ICaracteristicaCasoDeUso;
using CasosDeUsos.InterfacesCasosDeUso.IDireccionCasoDeUso;
using CasosDeUsos.InterfacesCasosDeUso.IMaquinariaCasosDeUso;
using CasosDeUsos.InterfacesCasosDeUso.IPublicacionVenta;
using CasosDeUsos.InterfacesCasosDeUso.IPublicacionVentaCasosDeUso;
using CasosDeUsos.InterfacesCasosDeUso.IUsuarioCasosDeUso;
using Dominio.InterfacesRepositorio.InterfacesRepositorioCaracteristicas;
using Dominio.InterfacesRepositorio.InterfacesRepositorioDireccion;
using Dominio.InterfacesRepositorio.InterfacesRepositorioMaquinarias;
using Dominio.InterfacesRepositorio.IRepositorioPublicacionVenta;
using Dominio.InterfacesRepositorio.IRepositorioRol;
using Dominio.InterfacesRepositorio.IRepositorioUsuario;
using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios.RepositorioCaracteristicas;
using LogicaAccesoDatos.Repositorios.RepositorioDirecciones;
using LogicaAccesoDatos.Repositorios.RepositorioPublicacionVenta;
using LogicaAccesoDatos.Repositorios.RepositorioRol;
using LogicaAccesoDatos.Repositorios.RepositoriosMaquinarias;
using LogicaAccesoDatos.Repositorios.RepositorioUsuario;
using LogicaAplicacion.CasosDeUso.CasosDeUsoCaracteristica;
using LogicaAplicacion.CasosDeUso.CasosDeUsoDireccion;
using LogicaAplicacion.CasosDeUso.CasosDeUsoMaquinaria;
using LogicaAplicacion.CasosDeUso.CasosDeUsoPublicacionVenta;
using LogicaAplicacion.CasosDeUso.CasosDeUsoUsuario;
using Microsoft.EntityFrameworkCore;

namespace WebAgro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Repositorios
            builder.Services.AddScoped<IRepositorioCaracteristica, RepositorioCaracteristicasEF>();
            builder.Services.AddScoped<IRepositorioDireccion, RepositorioDireccionEF>();
            builder.Services.AddScoped<IRepositorioMaquinaria, RepositorioMaquinaria>();
            builder.Services.AddScoped<IRepositorioPublicacionVenta, RepositorioPublicacionVenta>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioRol, RepositorioRol>();



            //Casos de uso
            builder.Services.AddScoped<ICUAltaDireccion, CUAltaDireccion>();
            builder.Services.AddScoped<ICUAltaCaracteristica, CUAltaCaracteristica>();


            builder.Services.AddScoped<ICUAltaMaquinariaTractor, CUAltaMaquinariaTractor>();
            builder.Services.AddScoped<ICUAltaMaquinariaSembradora, CUAltaMaquinariaSembradora>();
            builder.Services.AddScoped<ICUAltaMaquinariaFertilizadora, CUAltaMaquinariaFertilizadora>();
            builder.Services.AddScoped<ICUAltaMaquinariaCosechadora, CUAltaMaquinariaCosechadora>();

            builder.Services.AddScoped<ICUAltaUsuarioCliente, CUAltaUsuarioCliente>();
            builder.Services.AddScoped<ICULoginUsuario, CULoginUsuario>();

            builder.Services.AddScoped<ICUListadoPublicacionesVenta, CUListadoPublicacionesVenta>();
            builder.Services.AddScoped<ICUBuscarPublicacionEnVenta, CUBuscarPublicacionEnVenta>();
            builder.Services.AddScoped<ICUAltaPublicacionVenta, CUAltaPublicacionVenta>();








            string conexionDB = builder.Configuration.GetConnectionString("CadenaConexionAgro");
            builder.Services.AddDbContext<EmpresaContexto>(options => options.UseSqlServer(conexionDB));





            //para trabajar con Session:
            builder.Services.AddSession();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //para trabajar con Session:
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
    

            app.Run();
        }
    }
}
