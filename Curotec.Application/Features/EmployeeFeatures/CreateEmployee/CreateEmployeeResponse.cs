using Curotec.Domain.Entities;

namespace Curotec.Application.Features.EmployeeFeatures.CreateEmployee
{
    /// <summary>
    /// Represents the response for creating an employee.
    /// </summary>
    public sealed record CreateEmployeeResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the employee.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the department the employee belongs to.
        /// </summary>
        public Department? Department { get; set; }
    }
}
