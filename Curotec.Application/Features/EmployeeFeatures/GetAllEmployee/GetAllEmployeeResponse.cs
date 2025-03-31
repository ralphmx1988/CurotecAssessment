namespace Curotec.Application.Features.EmployeeFeatures.GetAllEmployee
{
    /// <summary>
    /// Represents the response containing details of an employee.
    /// </summary>
    public sealed record GetAllEmployeeResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the employee.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string? LastName { get; set; }
    }
}
