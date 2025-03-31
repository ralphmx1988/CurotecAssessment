using FluentValidation;

namespace Curotec.Application.Features.EmployeeFeatures.CreateEmployee
{
    /// <summary>
    /// Validator for creating an employee.
    /// </summary>
    public sealed class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEmployeeValidator"/> class.
        /// </summary>
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress()
                .WithMessage("Email is required and must be a valid email address with a maximum length of 50 characters.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage("First name is required and must be between 3 and 50 characters long.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage("Last name is required and must be between 3 and 50 characters long.");

            RuleFor(x => x.DepartmentId)
                .NotEmpty()
                .WithMessage("Department ID is required.");
        }
    }
}