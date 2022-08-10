using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.Department.Core.Dto;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.Core.Commands.Employee.Create
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IRepository<Core.Entities.Employee> _repository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IRepository<Core.Entities.Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = _mapper.Map<Core.Entities.Employee>(request.EmployeeDto);

            await _repository.AddAsync(employeeEntity, cancellationToken);

            return request.EmployeeDto;
        }
    }
}
