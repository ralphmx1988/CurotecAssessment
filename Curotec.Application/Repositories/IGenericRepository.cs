using Curotec.Domain.Common;
using System.Linq.Expressions;

namespace Curotec.Application.Repositories
{
    /// <summary>
    /// Generic repository interface for CRUD operations.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added entity.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deleted entity.</returns>
        Task<T?> DeleteAsync(int id);

        /// <summary>
        /// Gets an entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">The expression to filter the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a list of entities that match the specified predicate.
        /// </summary>
        /// <param name="predicate">The expression to filter the entities.</param>
        /// <returns>A collection of entities that match the predicate.</returns>
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a list of entities that match the specified predicate asynchronously.
        /// </summary>
        /// <param name="predicate">The expression to filter the entities.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities that match the predicate.</returns>
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="objModel">The entity to update.</param>
        void Update(T objModel);
    }
}
