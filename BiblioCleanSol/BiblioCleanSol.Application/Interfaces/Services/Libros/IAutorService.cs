using BiblioCleanSol.Application.Dtos.Libros.Autor;
using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Application.Interfaces.Services.Libros
{
    public interface IAutorService
    {
        //Todos los contratos deben devolver un Dto
        Task<OperationResult> ObtenerAutoresAsync();
        //Task<OperationResult> ObtenerAutorPorIdAsync(int id);
        Task<OperationResult> GuardarAutorAsync(AutorDto autorDto);
        Task<OperationResult> EditarAutorAsync(AutorEditarDto autorDto);
        //Task<OperationResult> BorrarAutorPorIdAsync(int id);
    }
}
