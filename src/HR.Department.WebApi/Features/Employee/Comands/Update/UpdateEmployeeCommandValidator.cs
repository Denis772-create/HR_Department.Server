using System;
using FluentValidation;

namespace HR.Department.WebApi.Features.Employee.Comands.Update
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
            RuleFor(command => command.Address.City).NotEmpty().MaximumLength(180);
            RuleFor(command => command.Address.Country).NotEmpty().MaximumLength(90);
            RuleFor(command => command.Address.Street).NotEmpty().MaximumLength(100);
        }
    }
}
