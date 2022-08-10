using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.Department.Core.Dto;
using HR.Department.Core.Exeptions;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.Core.Queries.Employee.GetAllQuery
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, EmployeeListDto>
    {
        private readonly IRepository<Core.Entities.Employee> _repository;
        private readonly IMapper _mapper;

        public GetEmployeeListQueryHandler(IRepository<Core.Entities.Employee> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeListDto> Handle(GetEmployeeListQuery request,
            CancellationToken cancellationToken)
        {
            var listEmployee = await _repository.ListAsync(cancellationToken);
            if (listEmployee == null)
                throw new NotFoundException(default, default);

            var listEmplVm = _mapper.Map<List<EmployeeDto>>(listEmployee);

            return await Task.FromResult(new EmployeeListDto { EmployeeList = listEmplVm });
        }
    }
}
