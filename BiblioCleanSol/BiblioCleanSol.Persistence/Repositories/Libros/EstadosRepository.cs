using BiblioCleanSol.Application.Interfaces.Repositories.Libros;
using BiblioCleanSol.Domain.Base;
using BiblioCleanSol.Domain.Entities.Libros;
using BiblioCleanSol.Persistence.Base;
using BiblioCleanSol.Persistence.Context;

namespace BiblioCleanSol.Persistence.Repositories.Libros
{
    //TODO: Hacer las validaciones de campo
    public sealed class EstadosRepository : BaseRepository<Estados>, IEstadosRepo
    {
        public EstadosRepository(Biblio_dbContext dbContext) : base(dbContext)
        {
        }

        //Los metodos del padre se deben llamar a traves del override.
        //Cada metodo debe implementar la logica de negocio que se necesite antes de: guardar, editar y obtener un Estado.
        public override Task<OperationResult> GuardarAsync(Estados estados)
        {
            return base.GuardarAsync(estados);
        }

        //Metodo adicional que esta entidad pueda necesitar.
    }
}
