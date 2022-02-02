using System;
using System.Threading.Tasks;
using HR.Department.WebApi.Features.Employee.Comands.Create;
using HR.Department.WebApi.Features.Employee.Comands.Update;
using HR.Department.WebApi.Features.Employee.Queries.GetEmployeeListByIdPosition;
using HR.Department.WebApi.Features.Position.Comands.UpdateSalaryForEmloyees;
using HR.Department.WebApi.Filters.ActionFilters;
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

        [HttpPost]
        [Validation]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody] EmployeeDto employee) =>
            Ok(await Mediator.Send(new CreateEmployeeCommand { EmployeeDto = employee }));

        [HttpPut]
        public async Task<ActionResult<int>> UpdatedSalaries() =>
            Ok(await Mediator.Send(new UpdateSalaryForEmloyeesCommand()));

        [HttpPut("{id}")]
        [Validation]
        public async Task<IActionResult> UpdateAddress(Guid id, [FromBody] AddressDto address) =>
            Ok(await Mediator.Send(new UpdateEmployeeCommand
            {
                Id = id,
                Address = address
            }));
    }
}
