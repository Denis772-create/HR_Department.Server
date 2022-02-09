using System;
using MediatR;

namespace HR.Department.Core.Commands.Position.DeletePosition
{
    public class DeletePositionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
