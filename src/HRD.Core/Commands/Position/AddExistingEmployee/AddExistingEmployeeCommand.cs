using System;
using MediatR;

namespace HR.Department.Core.Commands.Position.AddExistingEmployee
{
    public class AddExistingEmployeeCommand : IRequest
    {
        public Guid PositionId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
