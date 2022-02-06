using System.Threading;
using System.Threading.Tasks;
using HR.Department.Core.Entities.ValueObjects;
using HR.Department.Core.Exeptions;
using HR.Department.Core.Interfaces;
using HR.Department.Core.Specifications;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Comands.AddNewEmployee
{
    public class AddNewEmployeeToPositionCommandHandler : IRequestHandler<AddNewEmployeeToPositionCommand>
    {
        private readonly IRepository<Core.Entities.Position> _posRepository;
        private readonly IRepository<Core.Entities.Employee> _emplRepository;

        public AddNewEmployeeToPositionCommandHandler(IRepository<Core.Entities.Position> posRepository,
            IRepository<Core.Entities.Employee> emplRepository)
        {
            _posRepository = posRepository;
            _emplRepository = emplRepository;
        }


        public async Task<Unit> Handle(AddNewEmployeeToPositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _posRepository.GetByIdAsync(request.PositionId, cancellationToken);
            if (position is null) throw new NotFoundException(default, default);

            var employeeByPhoneSpecification = new EmployeeByPhoneSpecification(request.Phone);
            var employee = await _emplRepository.GetBySpecAsync(employeeByPhoneSpecification, cancellationToken);

            if (employee == null)
            {
                position.AddEmployee(new Core.Entities.Employee(
                    request.FirstName,
                    request.Surname,
                    new Address(request.Street, request.City, request.Country),
                    request.Phone,
                    request.Age,
                    request.RequiredSalary));
            }
            else
                position.AddEmployee(employee);

            await _posRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
