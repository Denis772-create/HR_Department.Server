using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.Department.Core.Exeptions;
using HR.Department.Core.Interfaces;
using HR.Department.WebApi.Modes;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Queries.GetPositionList
{
    public class GetPositionListQueryHandler : IRequestHandler<GetPositionListQuery, PositionListVm>
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

        public async Task<PositionListVm> Handle(GetPositionListQuery request, CancellationToken cancellationToken)
        {
            var listPositions = await _repository.ListAsync(cancellationToken);

            if (listPositions == null)
                throw new NotFoundException(typeof(Core.Entities.Position).ToString(), default);

            return new PositionListVm
            {
                PositionList = _mapper.Map<IList<PositionDto>>(listPositions)
            };
        }
    }
}
