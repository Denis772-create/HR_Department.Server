using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.Department.Core.Dto;
using HR.Department.Core.Exeptions;
using HR.Department.Core.Interfaces;
using HR.Department.Core.Specifications;
using MediatR;

namespace HR.Department.Core.Queries.Employee.GetEmployeeListByIdPosition
{
    public class GetEmployeeListByIdPositionQueryHandler : IRequestHandler<GetEmployeeListByIdPositionQuery, EmployeeListDto>
    {
        private readonly IRepository<Core.Entities.Employee> _repository;
        private readonly IMapper _mapper;

        public GetEmployeeListByIdPositionQueryHandler(
            IRepository<Core.Entities.Employee> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeListDto> Handle(GetEmployeeListByIdPositionQuery request, 
            CancellationToken cancellationToken)
        {
            var employListSpecification = new EmployeesSpecification(request.PositionId);
            var listEmpl = await _repository.ListAsync(employListSpecification, cancellationToken);

            if (listEmpl == null)
                throw new NotFoundException(nameof(List<Core.Entities.Employee>), default);

            var listEmplVm = _mapper.Map<List<EmployeeDto>>(listEmpl);

            return await Task.FromResult(new EmployeeListDto { EmployeeList = listEmplVm });
        }
    }
}
