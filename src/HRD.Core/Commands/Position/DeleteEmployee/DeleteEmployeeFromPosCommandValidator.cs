using System;
using FluentValidation;

namespace HR.Department.Core.Commands.Position.DeleteEmployee
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
