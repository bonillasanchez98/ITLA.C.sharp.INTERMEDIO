using BiblioCleanSol.Application.Dtos.Libros.Categoria;
using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Application.Interfaces.Services.Libros
{
    public interface ICategoriaService
    {
        Task<OperationResult> ObtenerCategoriasAsync();
        Task<OperationResult> GuardarAutorAsync(CategoriaDto categoriaDto);
        Task<OperationResult> EditarAutorAsync(CategoriaEditarDto  categoriaEditarDto);
    }
}
