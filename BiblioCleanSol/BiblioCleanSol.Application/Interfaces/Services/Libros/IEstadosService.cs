using BiblioCleanSol.Application.Dtos.Libros.Estados;
using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Application.Interfaces.Services.Libros
{
    public interface IEstadosService
    {
        Task<OperationResult> ObtenerEstadosAsync();
        Task<OperationResult> GuardarEstadosAsync(EstadosDto estadosDto);
        Task<OperationResult> EditarEstadosAsync(EstadosEditarDto estadosEditarDto);

    }
}
