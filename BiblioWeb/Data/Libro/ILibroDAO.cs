using BiblioWeb.Models.Result;

namespace BiblioWeb.Data.Libro
{
    public interface ILibroDAO
    {
        Task<OperationResult> AddBookAsync(Libro libro);
        Task<OperationResult> GetAllBooksAsync();
        Task<OperationResult> GetBookAsync(int id);
        Task<OperationResult> UpdateBookAsync(Libro libro);
    }
}
