using BiblioCleanSol.Domain.Base;
using System.Linq.Expressions;

namespace BiblioCleanSol.Application.Interfaces.Repositories
{
    /// <summary>
    /// Repositorio base donde estaran los metodos comunes que tendran cada repositorio.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepo<TEntity> where TEntity : class
    {
        /// <summary>
        /// Metodo para filtrar todas las entidades que se encuentren segun el criterio parametrizado.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        Task<OperationResult> ObtenerTodosAsync(Expression<Func<TEntity, bool>> filtro);

        /// <summary>
        /// Metodo para obtener una entidad por su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResult> ObtenerPorIdAsync(int id);

        /// <summary>
        /// Metodo para guardar una entidad.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<OperationResult> GuardarAsync(TEntity entity);

        /// <summary>
        /// Metodo para editar una entidad.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<OperationResult> EditarAsync(TEntity entity);

        /// <summary>
        /// Metodo para borrar una entidad (Borrado logico).
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<OperationResult> BorrarAsync(TEntity entity);

        /// <summary>
        /// Metodo para determinar su una entidad existe segun el filtro parametrizado.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        Task<bool> ExisteAsyn(Expression<Func<TEntity, bool>> filtro);
    }
}
