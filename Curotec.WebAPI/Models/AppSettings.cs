namespace Curotec.WebAPI.Models
{
    /// <summary>
    /// Represents the application settings.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Gets or sets the secret key used for authentication.
        /// </summary>
        public string Secret { get; set; } = string.Empty;
    }
}
