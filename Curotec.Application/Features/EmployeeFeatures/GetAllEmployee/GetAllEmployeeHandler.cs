using AutoMapper;
using Curotec.Application.Repositories;
using MediatR;

namespace Curotec.Application.Features.EmployeeFeatures.GetAllEmployee
{
    /// <summary>
    /// Handles the request to get all employees.
    /// </summary>
    public sealed class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeRequest, List<GetAllEmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllEmployeeHandler"/> class.
        /// </summary>
        /// <param name="employeeRepository">The employee repository.</param>
        /// <param name="mapper">The mapper.</param>
        public GetAllEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the request to get all employees.
        /// </summary>
        /// <param name="request">The request to get all employees.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of employee responses.</returns>
        public async Task<List<GetAllEmployeeResponse>> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
        {
            var users = await _employeeRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<GetAllEmployeeResponse>>(users);
        }
    }
}
