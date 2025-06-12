using BiblioCleanSol.Application.Interfaces.Repositories.Usuarios;
using BiblioCleanSol.Domain.Entities.Seguridad;
using BiblioCleanSol.Persistence.Base;
using BiblioCleanSol.Persistence.Context;

namespace BiblioCleanSol.Persistence.Repositories.Usuarios
{
    //TODO: Hacer las validaciones de campo
    public sealed class DocenteRepository : BaseRepository<Docente>, IDocenteRepo
    {
        public DocenteRepository(Biblio_dbContext dbContext) : base(dbContext)
        {
        }

        //Los metodos del padre se deben llamar a traves del override.
        //Cada metodo debe implementar la logica de negocio que se necesite antes de: guardar, editar y obtener un Docente.

        //Metodo adicional que esta entidad pueda necesitar.
    }
}
