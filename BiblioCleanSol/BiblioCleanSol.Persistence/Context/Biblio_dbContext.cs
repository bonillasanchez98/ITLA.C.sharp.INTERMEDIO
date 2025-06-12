using BiblioCleanSol.Domain.Base;
using BiblioCleanSol.Domain.Entities.Libros;
using BiblioCleanSol.Domain.Entities.Prestamo;
using BiblioCleanSol.Domain.Entities.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace BiblioCleanSol.Persistence.Context
{
    //Contexto de conexion de la base de datos SQLServer
    public class Biblio_dbContext : DbContext
    {
        //Aqui el contexto recibira las opciones de conexion desde el archivo de config (appsettings.json).
        public Biblio_dbContext(DbContextOptions<Biblio_dbContext> options) : base(options)
        {
        }

        //Definicion de los DbSet
        public DbSet<Autor> Autor { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Estados> Estados { get; set; }

        public DbSet<Libro> Libro { get; set; }

        public DbSet<Prestamo> Prestamos { get; set; }

        public DbSet<Rol> Rol { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
