using Curotec.Application.Repositories;
using Curotec.Persistence.Context;

namespace Curotec.Persistence.Repositories
{
    /// <summary>
    /// Represents a unit of work that encapsulates a set of operations to be performed on the data store.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CurotecContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by this unit of work.</param>
        public UnitOfWork(CurotecContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Saves all changes made in this unit of work to the data store.
        /// </summary>
      
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public Task Save(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}