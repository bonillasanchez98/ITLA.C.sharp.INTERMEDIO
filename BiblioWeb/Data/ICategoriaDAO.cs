using BiblioWeb.Models.Result;

namespace Biblio.Web.Data
{
    public interface ICategoriaDAO
    {
        Task<OperationResult> GetAllCategoriesAsync();
        Task<OperationResult> GetCategoryAsync(int id);
        Task<OperationResult> AddCategoryAsync(Categoria categoria);
        Task<OperationResult> UpdateCategoryAsync(Categoria categoria);
    }
}
