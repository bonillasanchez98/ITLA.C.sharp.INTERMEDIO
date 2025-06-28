using BiblioCleanSol.Application.Interfaces.Repositories;
using BiblioCleanSol.Domain.Base;
using BiblioCleanSol.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BiblioCleanSol.Persistence.Base
{
    /// <summary>
    /// Clase abstracta que implementa de la interface IBaseRepo<TEntity>
    /// donde firma los contratos y estos seran el comportamiento por defecto que tendra esta clase.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseRepository<TEntity> : IBaseRepo<TEntity> where TEntity : class
    {
        private readonly Biblio_dbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        //La entidad (TEntity ) recibida debe ser un DbSet perteneciente al context (SQLServer). [Autor, Libro, etc..]
        //Inyectando el Context a traves del constructor.
        public BaseRepository(Biblio_dbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Metodo para borrar (borrado logico) una TEntity desde la BD.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> BorrarAsync(TEntity entity)
        {
            OperationResult opResult = new OperationResult();
            try
            {
                _dbSet.Update(entity);
                await _dbContext.SaveChangesAsync();
                opResult = OperationResult.Success($"Entidad {typeof(TEntity)} borrada con existo!", entity);
            }
            catch (Exception)
            {
                opResult = OperationResult.Failure($"Error borrando entidad {typeof(TEntity)} en la BD.");
            }
            return opResult;
        }

        /// <summary>
        /// Metodo para editar una TEntity desde la BD.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> EditarAsync(TEntity entity)
        {
            OperationResult opResult = new OperationResult();
            try
            {
                _dbSet.Update(entity);
                await _dbContext.SaveChangesAsync();
                opResult = OperationResult.Success($"Entidad {typeof(TEntity)} editada con existo!", entity);
            }
            catch (Exception)
            {
                opResult = OperationResult.Failure($"Error editando entidad {typeof(TEntity)} en la BD.");
            }
            return opResult;
        }

        /// <summary>
        /// Metodo para validar si una TEntity existe en la BD.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> ExisteAsyn(Expression<Func<TEntity, bool>> filtro)
        {
            OperationResult opResult = new OperationResult();
            var exsite = await _dbSet.AsNoTracking()
                            .FirstOrDefaultAsync( filtro );

            return opResult = OperationResult.Success($"{typeof(TEntity)} existe", exsite);
        }

        /// <summary>
        /// Metodo para guardar una TEntity en la BD.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> GuardarAsync(TEntity entity)
        {
            OperationResult opResult = new OperationResult();
            try
            {
                _dbSet.Add(entity);
                await _dbContext.SaveChangesAsync();
                opResult = OperationResult.Success($"Entidad {typeof(TEntity)} agregada con existo!", entity);
            }
            catch (Exception ex)
            {
                opResult = OperationResult.Failure($"Error guardando entidad {typeof(TEntity)} en la BD.");
                return opResult;
            }
            return opResult;
        }

        /// <summary>
        /// Metodo para obtener una TEntity a traves de su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> ObtenerPorIdAsync(int id)
        {
            OperationResult opResult = new OperationResult();
            try
            {
                //_dbSet.SingleOrDefault(e => EF.Property<int>(e, "Id") == id); //Busque por index desde BD
                var entity = await _dbSet.FindAsync(id);
                if(entity is null)
                {
                    opResult = OperationResult.Failure($"Entidad no encontrada en la BD.");
                    return opResult;
                }
                opResult = OperationResult.Success($"Entidad {typeof(TEntity)} devuelta con existo!", entity);
                return opResult;
            }
            catch (Exception ex)
            {
                opResult = OperationResult.Failure($"Error retornando entidad {typeof(TEntity)} desde la BD");
                return opResult;
            }
        }

        /// <summary>
        /// Metodo para obtener todas las TEntity desde la BD.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> ObtenerTodosAsync(Expression<Func<TEntity, bool>> filtro)
        {
            OperationResult opResult = new OperationResult();
            try
            {
                var entities = await _dbSet.Where(filtro).ToListAsync();
                opResult = OperationResult.Success($"Entidades {typeof(TEntity)} devueltas con existo!", entities);
                return opResult;
            }
            catch (Exception ex)
            {
                opResult = OperationResult.Failure($"Error retornando entidad {typeof(TEntity)} desde la BD");
                return opResult;
            }
        }
    }
}
