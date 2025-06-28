using BiblioCleanSol.Application.Interfaces.Repositories.Usuarios;
using BiblioCleanSol.Domain.Base;
using BiblioCleanSol.Domain.Base.utils;
using BiblioCleanSol.Domain.Entities.Seguridad;
using BiblioCleanSol.Persistence.Base;
using BiblioCleanSol.Persistence.Context;
using System.Text.RegularExpressions;

namespace BiblioCleanSol.Persistence.Repositories.Usuarios
{
    //TODO: Hacer las validaciones de campo
    public sealed class RolRepository : BaseRepository<Rol>, IRolRepo
    {
        public RolRepository(Biblio_dbContext dbContext) : base(dbContext)
        {
        }

        //Los metodos del padre se deben llamar a traves del override.
        //Cada metodo debe implementar la logica de negocio que se necesite antes de: guardar, editar y obtener un Rol.
        public override Task<OperationResult> GuardarAsync(Rol rol)
        {
            OperationResult result = new OperationResult();

            if(rol is null)
            {
                result = OperationResult.Failure("El rol no puede ser nulo");
            }
            if (String.IsNullOrWhiteSpace(rol!.Nombre))
            {
                result = OperationResult.Failure("El nombre de rol no puede ser nulo");
            }
            if(rol.Nombre.Length > 50)
            {
                result = OperationResult.Failure("El nombre de rol no puede exceder los 50 caracteres");
            }
            if(Regex.IsMatch(rol.Nombre, ExpresionesReg.STRING_PATTERN))
            {
                result = OperationResult.Failure("Formato de nombre de rol invalido");
            }

            rol.elimino = false;

            rol.usuario_creacion_id = 2;
            rol.fecha_creacion = DateTime.Now;

            rol.usuario_mod = null;
            rol.fecha_mod = null;

            rol.usuario_elim_id = null;
            rol.fecha_elim = null;

            return base.GuardarAsync(rol);
        }


        public override Task<OperationResult> EditarAsync(Rol rol)
        {
            OperationResult result = new OperationResult();

            if (rol is null)
            {
                result = OperationResult.Failure("El rol no puede ser nulo");
            }
            if (String.IsNullOrWhiteSpace(rol!.Nombre))
            {
                result = OperationResult.Failure("El nombre de rol no puede ser nulo");
            }
            if (rol.Nombre.Length > 50)
            {
                result = OperationResult.Failure("El nombre de rol no puede exceder los 50 caracteres");
            }
            if (Regex.IsMatch(rol.Nombre, ExpresionesReg.STRING_PATTERN))
            {
                result = OperationResult.Failure("Formato de nombre de rol invalido");
            }

            rol.usuario_mod = 2;
            rol.fecha_mod = DateTime.Now;

            return base.EditarAsync(rol);    
        }

        public override Task<OperationResult> BorrarAsync(Rol rol)
        {
            rol.elimino = true;

            rol.usuario_elim_id = 2;
            rol.fecha_elim = DateTime.Now;

            return base.BorrarAsync(rol);
        }

        //Metodo adicional que esta entidad pueda necesitar.
    }
}
