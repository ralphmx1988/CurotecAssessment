using AutoMapper;
using Curotec.Domain.Entities;

namespace Curotec.Application.Features.EmployeeFeatures.CreateEmployee
{
    /// <summary>
    /// Mapper profile for creating an employee.
    /// </summary>
    public sealed class CreateEmployeeMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEmployeeMapper"/> class.
        /// </summary>
        public CreateEmployeeMapper()
        {
            CreateMap<CreateEmployeeRequest, Employee>();
            CreateMap<Employee, CreateEmployeeResponse>();
        }
    }
}
