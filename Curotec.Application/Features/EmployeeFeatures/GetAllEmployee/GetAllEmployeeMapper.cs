using AutoMapper;
using Curotec.Domain.Entities;

namespace Curotec.Application.Features.EmployeeFeatures.GetAllEmployee
{
    /// <summary>
    /// Mapper profile for mapping Employee entity to GetAllEmployeeResponse.
    /// </summary>
    public sealed class GetAllEmployeeMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllEmployeeMapper"/> class.
        /// Configures the mapping between Employee and GetAllEmployeeResponse.
        /// </summary>
        public GetAllEmployeeMapper()
        {
            CreateMap<Employee, GetAllEmployeeResponse>();
        }
    }
}