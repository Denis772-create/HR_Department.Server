using System.Threading;
using System.Threading.Tasks;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.Core.Commands.Position.DeleteEmployee
{
    public class DeleteEmployeeFromPosCommandHandler : IRequestHandler<DeleteEmployeeFromPosCommand>
    {
        private readonly IRepository<Core.Entities.Position> _repository;

        public DeleteEmployeeFromPosCommandHandler(IRepository<Core.Entities.Position> repository) =>
            _repository = repository;

        public async Task<Unit> Handle(DeleteEmployeeFromPosCommand request, CancellationToken cancellationToken)
        {
            var position = await _repository.GetByIdAsync(request.PositionId, cancellationToken);

            if (position != null)
            {
                position.RemoveEmployee(request.EmployeeId);
                await _repository.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
