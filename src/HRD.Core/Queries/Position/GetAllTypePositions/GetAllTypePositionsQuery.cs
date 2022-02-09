using System.Collections.Generic;
using HR.Department.Core.Dto;
using MediatR;

namespace HR.Department.Core.Queries.Position.GetAllTypePositions
{
    public class GetAllTypePositionsQuery : IRequest<IEnumerable<TypePositionDto>>
    {
    }
}
