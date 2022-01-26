using System;
using HR.Department.WebApi.Modes;
using MediatR;

namespace HR.Department.WebApi.Features.Employee.Queries.GetEmployeeListByIdPosition
{
    public class GetEmployeeListByIdPositionQuery : IRequest<EmployeeListVm>
    {
        public Guid PositionId { get; set; }
    }
}
