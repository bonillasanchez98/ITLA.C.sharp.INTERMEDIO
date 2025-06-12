using BiblioCleanSol.Application.Interfaces.Repositories.Prestamos;
using BiblioCleanSol.Domain.Entities.Prestamo;
using BiblioCleanSol.Persistence.Base;
using BiblioCleanSol.Persistence.Context;

namespace BiblioCleanSol.Persistence.Repositories.Prestamos
{
    //TODO: Hacer las validaciones de campo
    public sealed class PrestamosRepository : BaseRepository<Prestamo>, IPrestamosRepo
    {
        public PrestamosRepository(Biblio_dbContext dbContext) : base(dbContext)
        {
        }

        //Los metodos del padre se deben llamar a traves del override.
        //Cada metodo debe implementar la logica de negocio que se necesite antes de: guardar, editar y obtener un Prestamo.


        //Metodo adicional que esta entidad pueda necesitar.
    }
}
