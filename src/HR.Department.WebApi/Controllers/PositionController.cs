using System;
using System.Threading.Tasks;
using HR.Department.WebApi.Features.Position.Comands.AddEmployee;
using HR.Department.WebApi.Features.Position.Queries.GetPositionList;
using HR.Department.WebApi.Modes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Department.WebApi.Controllers
{
    public class PositionController : BaseController

    {
        [HttpGet]
        public async Task<ActionResult<PositionListVm>> GetAll() =>
            Ok(await Mediator.Send(new GetPositionListQuery()));

        [HttpPost("{id}")]
        public async Task<IActionResult> AddEmployeeToPosition(Guid id,
            [FromBody] EmployeeForAddingDto employeeForAddingDto) =>
            Ok(await Mediator.Send(new AddEmployeeToPositionCommand
            {
                PositionId = id,
                FirstName = employeeForAddingDto.FirstName,
                Surname = employeeForAddingDto.Surname,
                Street = employeeForAddingDto.Street,
                Country = employeeForAddingDto.Country,
                Age = employeeForAddingDto.Age,
                Phone = employeeForAddingDto.Phone,
                RequiredSalary = employeeForAddingDto.RequiredSalary,
                City = employeeForAddingDto.City
            }));

    }
}
