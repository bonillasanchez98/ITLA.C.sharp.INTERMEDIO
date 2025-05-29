namespace Biblio.Web.Data
{
    public interface ICategoriaDAO
    {
        Task<List<Categoria>> GetAllCategoriesAsync();
        Task<Categoria> GetCategoryAsync(int id);
        Task AddCategoryAsync(Categoria categoria);
        Task UpdateCategoryAsync(int id, Categoria categoria);
    }
}
