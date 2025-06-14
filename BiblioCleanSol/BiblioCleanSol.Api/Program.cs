
using BiblioCleanSol.Application.Interfaces.Repositories.Libros;
using BiblioCleanSol.Application.Interfaces.Services.Libros;
using BiblioCleanSol.Application.Services.Libros;
using BiblioCleanSol.Persistence.Context;
using BiblioCleanSol.Persistence.Repositories.Libros;
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

            //Service
            builder.Services.AddTransient<IAutorService, AutorService>();
            builder.Services.AddTransient<ICategoriaService, CategoriaService>();

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
