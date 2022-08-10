using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.Department.Core.Dto;
using HR.Department.Core.Exeptions;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.Core.Queries.Position.GetPositionList
{
    public class GetPositionListQueryHandler : IRequestHandler<GetPositionListQuery, PositionListDto>
    {
        private readonly IReadRepository<Core.Entities.Position> _repository;
        private readonly IMapper _mapper;

        public GetPositionListQueryHandler(
            IReadRepository<Core.Entities.Position> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PositionListDto> Handle(GetPositionListQuery request, CancellationToken cancellationToken)
        {
            var listPositions = await _repository.ListAsync(cancellationToken);

            if (listPositions == null)
                throw new NotFoundException(typeof(Core.Entities.Position).ToString(), default);

            return new PositionListDto
            {
                PositionList = _mapper.Map<IList<PositionDto>>(listPositions)
            };
        }
    }
}
