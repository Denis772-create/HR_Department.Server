using System;
using System.Threading;
using System.Threading.Tasks;
using HR.Department.Core.Entities.ValueObjects;
using HR.Department.Core.Interfaces;
using HR.Department.Core.Specifications;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Comands.AddEmployee
{
    public class AddEmployeeToPositionCommandHandler : IRequestHandler<AddEmployeeToPositionCommand>
    {
        private readonly IRepository<Core.Entities.Position> _posRepository;
        private readonly IRepository<Core.Entities.Employee> _emplRepository;

        public AddEmployeeToPositionCommandHandler(IRepository<Core.Entities.Position> posRepository,
            IRepository<Core.Entities.Employee> emplRepository)
        {
            _posRepository = posRepository;
            _emplRepository = emplRepository;
        }


        public async Task<Unit> Handle(AddEmployeeToPositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _posRepository.GetByIdAsync(request.PositionId, cancellationToken);

            var employeeByPhoneSpecification = new EmployeeByPhoneSpecification(request.Phone);
            var employee = await _emplRepository.GetBySpecAsync(employeeByPhoneSpecification);

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

            position.AddEmployee(employee);
            await _posRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
