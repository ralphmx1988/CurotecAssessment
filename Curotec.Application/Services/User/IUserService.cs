using Curotec.Application.Models;

namespace Curotec.Application.Services.User
{
    /// <summary>
    /// Interface for user service operations.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authenticates a user with the provided credentials.
        /// </summary>
        /// <param name="model">The authentication request model containing username and password.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the authentication response with user details and JWT token.</returns>
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);

        /// <summary>
        /// Gets all active users.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of active users.</returns>
        Task<IEnumerable<Domain.Entities.User>> GetAll();

        /// <summary>
        /// Gets a user by their identifier.
        /// </summary>
        /// <param name="id">The identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the user entity.</returns>
        Task<Domain.Entities.User?> GetById(int id);

        /// <summary>
        /// Adds or updates a user.
        /// </summary>
        /// <param name="userObj">The user entity to add or update.</param>
        /// <param name="cancellationToke"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added or updated user entity.</returns>
        Task<Domain.Entities.User?> AddOrUpdateUser(Domain.Entities.User userObj, CancellationToken cancellationToke);
    }
}
