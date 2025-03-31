namespace Curotec.Application.Models
{
    /// <summary>
    /// Represents the application settings.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Gets or sets the secret key used for application security.
        /// </summary>
        public string Secret { get; set; } = string.Empty;
    }
}
