using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.Department.Core.Entities.ValueObjects;
using HR.Department.Core.Exeptions;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.Core.Commands.Employee.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IRepository<Core.Entities.Employee> _repository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(
            IRepository<Core.Entities.Employee> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (employee == null)
                throw new NotFoundException(nameof(Core.Entities.Employee), request.Id);

            var address = _mapper.Map<Address>(request.Address);

            employee.UpdateAddress(address);
            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
