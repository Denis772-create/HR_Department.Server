using FluentValidation;

namespace HR.Department.WebApi.Features.Employee.Comands.Create
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(command => command.EmployeeDto.RequiredSalary).NotEmpty();
            RuleFor(command => command.EmployeeDto.Phone).NotEmpty().MaximumLength(20);
            RuleFor(command => command.EmployeeDto.FirstName).NotEmpty();
            RuleFor(command => command.EmployeeDto.Surname).NotEmpty();
        }
    }
}
