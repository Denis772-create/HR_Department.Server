using System;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Comands.DeleteEmployee
{
    public class DeleteEmployeeFromPosCommand : IRequest
    {
        public Guid PositionId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
