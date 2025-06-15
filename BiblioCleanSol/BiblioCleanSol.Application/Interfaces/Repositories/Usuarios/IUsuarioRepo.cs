using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Application.Interfaces.Repositories.Usuarios
{
    public interface IUsuarioRepo : IBaseRepo<Usuario>
    {
        Task<OperationResult> ObtenerUsuarioPorRolId(int RolId);
    }
}
