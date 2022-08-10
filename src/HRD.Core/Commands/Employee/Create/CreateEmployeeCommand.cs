using HR.Department.Core.Dto;
using MediatR;

namespace HR.Department.Core.Commands.Employee.Create
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public EmployeeDto EmployeeDto { get; set; }
    }
}
