using System;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Comands.DeletePosition
{
    public class DeletePositionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
