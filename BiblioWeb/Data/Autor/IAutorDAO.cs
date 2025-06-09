using BiblioWeb.Models.Result;

namespace BiblioWeb.Data.Autor
{
    public interface IAutorDAO
    {
        Task<OperationResult> GetAllAuthorsAsync();
        Task<OperationResult> AddAuthorAsync(Autor autor);
        Task<OperationResult> GetAuthorAsync(int id);
        Task<OperationResult> UpdateAuthorAsync(Autor autor);
    }
}
