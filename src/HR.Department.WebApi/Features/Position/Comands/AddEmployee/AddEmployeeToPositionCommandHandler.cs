using System;
using System.Threading;
using System.Threading.Tasks;
using HR.Department.Core.Entities.ValueObjects;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Comands.AddEmployee
{
    public class AddEmployeeToPositionCommandHandler : IRequestHandler<AddEmployeeToPositionCommand>
    {
        private readonly IRepository<Core.Entities.Position> _repository;

        public AddEmployeeToPositionCommandHandler(IRepository<Core.Entities.Position> repository) =>
            _repository = repository;

        public async Task<Unit> Handle(AddEmployeeToPositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _repository.GetByIdAsync<Guid>(request.PositionId, cancellationToken);

            position.AddEmployee(new Core.Entities.Employee(
                request.FirstName,
                request.Surname,
                new Address(request.Street, request.City, request.Country),
                request.Phone,
                request.Age));

            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
