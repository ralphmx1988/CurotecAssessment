using Curotec.Domain.Entities;

namespace Curotec.Application.Repositories
{
    /// <summary>
    /// Interface for employee repository, providing methods to interact with employee data.
    /// </summary>
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        /// <summary>
        /// Gets an employee by their email address.
        /// </summary>
        /// <param name="email">The email address of the employee.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the employee entity.</returns>
        Task<Employee?> GetByEmail(string email, CancellationToken cancellationToken);
    }
}
