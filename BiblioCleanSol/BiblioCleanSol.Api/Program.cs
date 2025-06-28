
using BiblioCleanSol.Application.Interfaces.Repositories.Libros;
using BiblioCleanSol.Application.Interfaces.Repositories.Usuarios;
using BiblioCleanSol.Application.Interfaces.Services.Libros;
using BiblioCleanSol.Application.Interfaces.Services.Usuarios;
using BiblioCleanSol.Application.Services.Libros;
using BiblioCleanSol.Application.Services.Usuarios;
using BiblioCleanSol.Persistence.Base;
using BiblioCleanSol.Persistence.Context;
using BiblioCleanSol.Persistence.Repositories.Libros;
using BiblioCleanSol.Persistence.Repositories.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace BiblioCleanSol.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddDbContextPool<>(); //Para manegar peticiones simultaneas.
            
            // Add services to the container.
            builder.Services.AddDbContext<Biblio_dbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("biblioConn")));

            //Repository
            builder.Services.AddScoped<IAutorRepo, AutorRepository>();
            builder.Services.AddScoped<ICategoriaRepo, CategoriaRepository>();
            builder.Services.AddScoped<IUsuarioRepo, UsuarioRepository>();
            builder.Services.AddScoped<IEstadosRepo, EstadosRepository>();
            builder.Services.AddScoped<IRolRepo, RolRepository>();

            //Service
            builder.Services.AddTransient<IAutorService, AutorService>();
            builder.Services.AddTransient<ICategoriaService, CategoriaService>();
            builder.Services.AddTransient<IUsuarioService, UsuarioService>();
            builder.Services.AddTransient<IEstadosService, EstadosService>();
            builder.Services.AddTransient<IRolService, RolService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
