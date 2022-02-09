using System;
using FluentValidation;

namespace HR.Department.Core.Commands.Position.AddNewEmployee
{
    public class AddNewEmployeeToPositionCommandValidator : AbstractValidator<AddNewEmployeeToPositionCommand>
    {
        public AddNewEmployeeToPositionCommandValidator()
        {
            RuleFor(command => command.PositionId).NotEqual(Guid.Empty);
            RuleFor(command => command.Phone).NotEmpty();
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.Surname).NotEmpty();
        }

    }
}
