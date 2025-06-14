using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Application.Interfaces.Services
{
    /// <summary>
    /// Este metedo base, solo tendras las operaciones de obtener entidades y borrar,
    /// ya que solo usaran id en sus parametros, para que cada implementacion defina
    /// sus propios metodos de guardar y editar.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    //public interface IBaseService<TEntity> where TEntity : class
    //{
    //    Task<OperationResult> ObtenerEntidadAsync();
    //    Task<OperationResult> ObtenerEntidadPorIdAsync(int id);
    //    Task<OperationResult> GuardarEntidadAsync(TEntity entidad);
    //    Task<OperationResult> EditarEntidadAsync(TEntity entidad);
    //    Task<OperationResult> BorrarEntidadPorIdAsync(int id);

    //}
}
