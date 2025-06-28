using BiblioCleanSol.Application.Dtos.Usuarios.Rol;
using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Application.Interfaces.Services.Usuarios
{
    public interface IRolService
    {
        Task<OperationResult> ObtenerRolesAsync();
        Task<OperationResult> GuardarRolAsync(RolDto rolDto);
        Task<OperationResult> EditarRolAsync(RolEditarDto rolEditarDto);
    }
}
 