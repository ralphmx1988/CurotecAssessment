using Curotec.Application.Features.EmployeeFeatures.CreateEmployee;
using Curotec.Application.Features.EmployeeFeatures.GetAllEmployee;
using Curotec.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Curotec.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing employees.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of all employees.</returns>
        [HttpGet]
        public async Task<ActionResult<List<GetAllEmployeeResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await mediator.Send(new GetAllEmployeeRequest(), cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="request">The request containing employee details.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The response containing the created employee's details.</returns>
        [HttpPost]
        public async Task<ActionResult<CreateEmployeeResponse>> Create(CreateEmployeeRequest request,
            CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}