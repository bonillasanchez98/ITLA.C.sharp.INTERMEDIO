using BiblioCleanSol.Application.Interfaces.Repositories.Libros;
using BiblioCleanSol.Domain.Entities.Libros;
using BiblioCleanSol.Persistence.Base;
using BiblioCleanSol.Persistence.Context;

namespace BiblioCleanSol.Persistence.Repositories.Libros
{
    //TODO: Hacer las validaciones de campo
    public sealed class LibroRepository : BaseRepository<Libro>, ILibroRepo
    {
        public LibroRepository(Biblio_dbContext dbContext) : base(dbContext)
        {
        }

        //Los metodos del padre se deben llamar a traves del override.
        //Cada metodo debe implementar la logica de negocio que se necesite antes de: guardar, editar y obtener un Libro.



        //Metodo adicional que esta entidad pueda necesitar.
    }
}
