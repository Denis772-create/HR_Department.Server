using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.Department.Core.Dto;
using HR.Department.Core.Entities;
using HR.Department.Core.Exeptions;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.Core.Queries.Position.GetAllTypePositions
{
    public class GetAllTypePositionsQueryHandler :
        IRequestHandler<GetAllTypePositionsQuery, IEnumerable<TypePositionDto>>
    {
        private readonly IRepository<TypePosition> _repository;
        private readonly IMapper _mapper;

        public GetAllTypePositionsQueryHandler(IRepository<TypePosition> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypePositionDto>> Handle(GetAllTypePositionsQuery request,
            CancellationToken cancellationToken)
        {
            var types = await _repository.ListAsync(cancellationToken);

            if (types == null)
                throw new NotFoundException(typeof(TypePosition).Name, default);

            return _mapper.Map<IEnumerable<TypePositionDto>>(types);
        }
    }
}
