using System;
using HR.Department.Core.Dto;
using MediatR;

namespace HR.Department.Core.Queries.Employee.GetEmployeeListByIdPosition
{
    public class GetEmployeeListByIdPositionQuery : IRequest<EmployeeListDto>
    {
        public Guid PositionId { get; set; }
    }
}
