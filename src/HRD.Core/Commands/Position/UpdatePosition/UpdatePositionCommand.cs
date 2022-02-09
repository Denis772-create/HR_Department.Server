using System;
using MediatR;

namespace HR.Department.Core.Commands.Position.UpdatePosition
{
    public class UpdatePositionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
