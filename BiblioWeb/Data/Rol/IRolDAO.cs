using BiblioWeb.Models.Result;

namespace BiblioWeb.Data.Rol
{
    public interface IRolDAO
    {
        Task<OperationResult> GetAllRoleAsync();
        Task<OperationResult> GetRoleAsync(int id);
        Task<OperationResult> AddRoleAsync(Rol rol);
        Task<OperationResult> UpdateRoleAsync(Rol rol);
    }
}
