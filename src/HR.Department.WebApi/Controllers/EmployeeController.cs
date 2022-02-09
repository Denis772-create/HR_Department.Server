using System;
using System.Threading.Tasks;
using HR.Department.Core.Commands.Employee.Create;
using HR.Department.Core.Commands.Employee.Update;
using HR.Department.Core.Commands.Position.UpdateSalaryForEmloyees;
using HR.Department.Core.Dto;
using HR.Department.Core.Queries.Employee.GetAllQuery;
using HR.Department.Core.Queries.Employee.GetEmployeeListByIdPosition;
using HR.Department.WebApi.Filters.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace HR.Department.WebApi.Controllers
{
    public class EmployeeController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<EmployeeListDto>> GetAll() =>
            Ok(await Mediator.Send(new GetEmployeeListQuery()));

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeListDto>> GetByIdPosition(Guid id) =>
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
