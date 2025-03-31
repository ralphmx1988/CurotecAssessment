using Curotec.Application.Repositories;
using Curotec.Domain.Common;
using Curotec.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace Curotec.Persistence.Repositories
{
    /// <summary>
    /// Generic repository for CRUD operations.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly CurotecContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public GenericRepository(CurotecContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Gets an entity by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity, or null if not found.</returns>
        public Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        /// <summary>
        /// Gets all entities asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities.</returns>
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await Context.Set<T>().ToListAsync(cancellationToken);
            return result.AsEnumerable();
        }

        /// <summary>
        /// Adds a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added entity.</returns>
        public async Task<T> AddAsync(T entity)
        {
            var entry = await Context.Set<T>().AddAsync(entity);
            return entry.Entity;
        }

        /// <summary>
        /// Deletes an entity by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deleted entity, or null if not found.</returns>
        public async Task<T?> DeleteAsync(int id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            Context.Set<T>().Remove(entity);
            return entity;
        }

        /// <summary>
        /// Gets an entity that matches the specified predicate asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate to filter the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity, or null if not found.</returns>
        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Gets a list of entities that match the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to filter the entities.</param>
        /// <returns>A collection of entities that match the predicate.</returns>
        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        /// <summary>
        /// Gets a list of entities that match the specified predicate asynchronously.
        /// </summary>
        /// <param name="predicate">The predicate to filter the entities.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities that match the predicate.</returns>
        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => Context.Set<T>().Where(predicate));
        }

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="objModel">The entity to update.</param>
        public void Update(T objModel)
        {
            Context.Entry(objModel).State = EntityState.Modified;
        }
    }
}

