using MediatR;

namespace Curotec.Application.Features.EmployeeFeatures.CreateEmployee
{
    /// <summary>
    /// Represents a request to create a new employee.
    /// </summary>
    /// <param name="FirstName">The first name of the employee.</param>
    /// <param name="LastName">The last name of the employee.</param>
    /// <param name="Email">The email address of the employee.</param>
    /// <param name="DepartmentId">The unique identifier of the department the employee belongs to.</param>
    public sealed record CreateEmployeeRequest(
        string FirstName,
        string LastName,
        string Email,
        int DepartmentId)
        : IRequest<CreateEmployeeResponse>;


}
