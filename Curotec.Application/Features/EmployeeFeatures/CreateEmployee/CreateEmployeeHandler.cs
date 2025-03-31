using AutoMapper;
using Curotec.Application.Repositories;
using Curotec.Domain.Entities;
using MediatR;

namespace Curotec.Application.Features.EmployeeFeatures.CreateEmployee
{
    /// <summary>
    /// Handles the creation of a new employee.
    /// </summary>
    public sealed class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEmployeeHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="employeeRepository">The employee repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CreateEmployeeHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the creation of a new employee.
        /// </summary>
        /// <param name="request">The request to create a new employee.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response for creating an employee.</returns>
        public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            await _employeeRepository.AddAsync(employee);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateEmployeeResponse>(employee);
        }
    }
}
