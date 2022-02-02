using System.Collections.Generic;
using HR.Department.WebApi.Modes;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Queries.GetAllTypePositions
{
    public class GetAllTypePositionsQuery : IRequest<IEnumerable<TypePositionDto>>
    {
    }
}
