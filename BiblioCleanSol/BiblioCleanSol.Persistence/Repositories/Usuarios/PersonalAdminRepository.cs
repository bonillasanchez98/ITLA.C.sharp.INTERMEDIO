using BiblioCleanSol.Application.Interfaces.Repositories.Usuarios;
using BiblioCleanSol.Domain.Base;
using BiblioCleanSol.Domain.Entities.Seguridad;
using BiblioCleanSol.Persistence.Base;
using BiblioCleanSol.Persistence.Context;

namespace BiblioCleanSol.Persistence.Repositories.Usuarios
{
    //TODO: Hacer las validaciones de campo
    public sealed class PersonalAdminRepository : BaseRepository<PersonalAdmin>, IPersonalAdminRepo
    {
        public PersonalAdminRepository(Biblio_dbContext dbContext) : base(dbContext)
        {
        }

        //Los metodos del padre se deben llamar a traves del override.
        //Cada metodo debe implementar la logica de negocio que se necesite antes de guardar, editar y obtener un PersonalAdmin.
        public override Task<OperationResult> GuardarAsync(PersonalAdmin personalAdmin)
        {
            return base.GuardarAsync(personalAdmin);
        }

        //Metodo adicional que esta entidad pueda necesitar.
    }
}
