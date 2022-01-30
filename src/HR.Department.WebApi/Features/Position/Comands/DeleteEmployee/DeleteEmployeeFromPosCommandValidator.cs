using System;
using FluentValidation;

namespace HR.Department.WebApi.Features.Position.Comands.DeleteEmployee
{
    public class DeleteEmployeeFromPosCommandValidator : AbstractValidator<DeleteEmployeeFromPosCommand>
    {
        public DeleteEmployeeFromPosCommandValidator()
        {
            RuleFor(command => command.PositionId).NotEqual(Guid.Empty);
            RuleFor(command => command.EmployeeId).NotEqual(Guid.Empty);

        }
    }
}
