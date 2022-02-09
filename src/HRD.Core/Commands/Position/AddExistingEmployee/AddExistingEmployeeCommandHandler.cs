using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.Core.Commands.Position.AddExistingEmployee
{
    public class AddExistingEmployeeCommandHandler : IRequestHandler<AddExistingEmployeeCommand>
    {
        private readonly IRepository<Core.Entities.Position> _posRepository;
        private readonly IRepository<Core.Entities.Employee> _emplRepository;

        public AddExistingEmployeeCommandHandler(IRepository<Core.Entities.Position> posRepository,
            IRepository<Core.Entities.Employee> emplRepository)
        {
            _posRepository = posRepository;
            _emplRepository = emplRepository;
        }

        public async Task<Unit> Handle(AddExistingEmployeeCommand request, CancellationToken cancellationToken)
        {
            var position = await _posRepository.GetByIdAsync(request.PositionId, cancellationToken);
            var employee = await _emplRepository.GetByIdAsync(request.EmployeeId, cancellationToken);

            if (position != null && employee != null)
            {
                if (!position.Employees.Contains(employee))
                {
                    position.AddEmployee(employee);
                    await _posRepository.SaveChangesAsync(cancellationToken);
                }
            }

            return Unit.Value;
        }
    }
}
