using System.Threading;
using System.Threading.Tasks;
using HR.Department.Core.Exeptions;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.Core.Commands.Position.UpdatePosition
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand>
    {
        private readonly IRepository<Core.Entities.Position> _repository;

        public UpdatePositionCommandHandler(IRepository<Core.Entities.Position> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var positionEntity = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (positionEntity == null)
                throw new NotFoundException(default, default);

            positionEntity.Update(request.Name, request.Description);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
