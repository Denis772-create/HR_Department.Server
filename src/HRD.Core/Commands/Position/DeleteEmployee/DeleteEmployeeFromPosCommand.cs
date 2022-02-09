using System;
using MediatR;

namespace HR.Department.Core.Commands.Position.DeleteEmployee
{
    public class DeleteEmployeeFromPosCommand : IRequest
    {
        public Guid PositionId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
