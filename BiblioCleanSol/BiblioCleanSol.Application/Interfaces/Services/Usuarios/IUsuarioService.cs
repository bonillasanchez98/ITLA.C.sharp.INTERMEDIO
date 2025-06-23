using BiblioCleanSol.Application.Dtos.Usuarios;
using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Application.Interfaces.Services.Usuarios
{
    public interface IUsuarioService
    {
        Task<OperationResult> ObtenerUsuariosAsync();
        Task<OperationResult> GuardarUsuarioAsync(UsuarioDto usuarioDto);
        Task<OperationResult> EditarUsuarioAsync(UsuarioEditarDto usuarioEditarDto);
    }
}
