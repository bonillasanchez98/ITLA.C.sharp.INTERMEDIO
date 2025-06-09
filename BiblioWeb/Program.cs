using BiblioWeb.Data.Categoria;
using BiblioWeb.Data.Rol;
using BiblioWeb.Data.Usuario;

namespace BiblioWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Aqui se registran todas las Inyecciones de Dependicias
            builder.Services.AddScoped<IUsuarioDAO, UsuarioDAO>();
            builder.Services.AddScoped<ICategoriaDAO, CategoriaDAO>();
            builder.Services.AddScoped<IRolDAO, RolDAO>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
