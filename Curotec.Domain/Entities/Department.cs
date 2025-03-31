using Curotec.Domain.Common;

namespace Curotec.Domain.Entities
{
    /// <summary>
    /// Represents a department within the organization.
    /// </summary>
    public class Department : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of employees in the department.
        /// </summary>
        public ICollection<Employee> Employees { get; set; } = [];
    }
}
