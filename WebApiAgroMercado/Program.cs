using CasosDeUsos.InterfacesCasosDeUso.IUsuarioCasosDeUso;
using Dominio.InterfacesRepositorio.IRepositorioRol;
using Dominio.InterfacesRepositorio.IRepositorioUsuario;
using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios.RepositorioRol;
using LogicaAccesoDatos.Repositorios.RepositorioUsuario;
using LogicaAplicacion.CasosDeUso.CasosDeUsoUsuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace WebApiAgroMercado
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioRol, RepositorioRol>();

            builder.Services.AddScoped<ICUBuscarUsuario, CUBuscarUsuario>();
            builder.Services.AddScoped<ICUAltaUsuarioCliente, CUAltaUsuarioCliente>();
            builder.Services.AddScoped<ICULoginUsuario, CULoginUsuario>();


            // //Add services to the container.
            String conexionDB = builder.Configuration.GetConnectionString("CadenaConexionAgro");
            builder.Services.AddDbContext<EmpresaContexto>(options => options.UseSqlServer(conexionDB));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //CORREGIR LO DE ABAJO LPM----------------------------------------------------------------.
            builder.Services.AddSwaggerGen(opt => opt.IncludeXmlComments("WebApiAgroMercado.xml"));
            //------------------------------------------------------------------------------------------/
            ////Comienza JWT////
            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
