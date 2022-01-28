using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.Department.Core.Interfaces;
using HR.Department.Core.Specifications;
using HR.Department.Infrastructure.Data;
using HR.Department.WebApi.Modes;
using MediatR;

namespace HR.Department.WebApi.Features.Employee.Queries.GetEmployeeListByIdPosition
{
    public class GetEmployeeListByIdPositionQueryHandler : IRequestHandler<GetEmployeeListByIdPositionQuery, EmployeeListVm>
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

        public async Task<EmployeeListVm> Handle(GetEmployeeListByIdPositionQuery request, CancellationToken cancellationToken)
        {
            var employListSpecification = new EmployeesSpecification(request.PositionId);
            var listEmpl = await _repository.ListAsync(employListSpecification, cancellationToken);

            var listEmplVm = _mapper.Map<List<EmployeeDto>>(listEmpl);

            return await Task.FromResult(new EmployeeListVm { EmployeeList = listEmplVm });
        }
    }
}
