using HR.Department.WebApi.Modes;
using MediatR;

namespace HR.Department.WebApi.Features.Employee.Queries.GetAllQuery
{
    public class GetEmployeeListQuery : IRequest<EmployeeListVm>, IRequest<Unit>
    {
        
    }
}
