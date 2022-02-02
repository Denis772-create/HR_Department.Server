using System;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Comands.CreatePosition
{
    public class CreatePositionCommand : IRequest
    {
        public Guid TypePositionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
