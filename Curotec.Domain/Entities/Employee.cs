using Curotec.Domain.Common;

namespace Curotec.Domain.Entities
{
    /// <summary>
    /// Represents an employee entity.
    /// </summary>
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public required string LastName { get; set; }


        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the department ID the employee belongs to.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the department the employee belongs to.
        /// </summary>
        public virtual Department? Department { get; set; }
    }
}
