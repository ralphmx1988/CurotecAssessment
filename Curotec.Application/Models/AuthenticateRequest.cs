using System.ComponentModel;

namespace Curotec.Application.Models
{
    /// <summary>
    /// Represents a request to authenticate a user.
    /// </summary>
    public class AuthenticateRequest
    {
        /// <summary>
        /// Gets or sets the username for authentication.
        /// Default value is "System".
        /// </summary>
        [DefaultValue("System")]
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the password for authentication.
        /// Default value is "System".
        /// </summary>
        [DefaultValue("System")]
        public required string Password { get; set; }
    }
}
