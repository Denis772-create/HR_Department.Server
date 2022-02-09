using System.Threading;
using System.Threading.Tasks;
using HR.Department.Core.Exeptions;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.Core.Commands.Position.DeletePosition
{
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand>
    {
        private readonly IRepository<Core.Entities.Position> _repository;

        public DeletePositionCommandHandler(IRepository<Core.Entities.Position> repository) =>
            _repository = repository;

        public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var positionEntity = await _repository.GetByIdAsync(request.Id, cancellationToken)
                                 ?? throw new NotFoundException(default, default);

            await _repository.DeleteAsync(positionEntity, cancellationToken);

            return Unit.Value;
        }
    }
}
