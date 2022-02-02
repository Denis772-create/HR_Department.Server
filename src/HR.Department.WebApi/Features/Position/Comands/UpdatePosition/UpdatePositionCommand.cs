using System;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Comands.UpdatePosition
{
    public class UpdatePositionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
