using BiblioWeb.Models.Result;

namespace BiblioWeb.Data.Usuario
{
    public interface IUsuarioDAO
    {
        Task<OperationResult> GetAllUsersAsync();
        Task<OperationResult> GetUserAsync(int id);
        Task<OperationResult> AddUserAsync(Usuario usuario);
        Task<OperationResult> UpdateUserAsync(Usuario usuario);
    }
}
