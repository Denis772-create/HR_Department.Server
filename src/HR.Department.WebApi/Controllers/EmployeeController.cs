using System;
using System.Threading.Tasks;
using HR.Department.WebApi.Features.Employee.Queries.GetEmployeeListByIdPosition;
using HR.Department.WebApi.Features.Position.Comands.UpdateSalaryForEmloyees;
using HR.Department.WebApi.Modes;
using Microsoft.AspNetCore.Mvc;

namespace HR.Department.WebApi.Controllers
{
    public class EmployeeController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeListVm>> GetByIdPosition(Guid id) =>
            Ok(await Mediator.Send(new GetEmployeeListByIdPositionQuery
            {
                PositionId = id
            }));

        [HttpPut]
        public async Task<ActionResult<int>> GetNumberUpdatedSalaries() =>
            await Mediator.Send(new UpdateSalaryForEmloyeesCommand());
    }
}
