using MediatR;

namespace Curotec.Application.Features.EmployeeFeatures.GetAllEmployee
{
    /// <summary>
    /// Represents a request to get all employees.
    /// </summary>
    public sealed record GetAllEmployeeRequest : IRequest<List<GetAllEmployeeResponse>>;
}
