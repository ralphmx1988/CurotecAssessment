using Curotec.Domain.Entities;

namespace Curotec.Application.Models
{
    /// <summary>
    /// Represents the response returned after a successful authentication.
    /// </summary>
    /// <param name="user">The authenticated user.</param>
    /// <param name="token">The JWT token generated for the authenticated user.</param>
    public class AuthenticateResponse(User user, string token)
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public int Id { get; set; } = user.Id;

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; } = user.FirstName;

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string? LastName { get; set; } = user.LastName;

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; } = user.Username;

        /// <summary>
        /// Gets or sets the JWT token generated for the authenticated user.
        /// </summary>
        public string Token { get; set; } = token;
    }
}