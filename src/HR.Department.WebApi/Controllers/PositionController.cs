using System;
using System.Threading.Tasks;
using AutoMapper;
using HR.Department.WebApi.Features.Position.Comands.AddEmployee;
using HR.Department.WebApi.Features.Position.Comands.DeleteEmployee;
using HR.Department.WebApi.Features.Position.Queries.GetPositionList;
using HR.Department.WebApi.Filters.ActionFilters;
using HR.Department.WebApi.Modes;
using Microsoft.AspNetCore.Mvc;

namespace HR.Department.WebApi.Controllers
{
    public class PositionController : BaseController

    {
        private readonly IMapper _mapper;
        public PositionController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PositionListVm>> GetAll() =>
            Ok(await Mediator.Send(new GetPositionListQuery()));

        [HttpPost("{id}")]
        [Validation]
        public async Task<IActionResult> AddEmployeeToPosition(Guid id,
            [FromBody] EmployeeForAddingDto employeeForAddingDto)
        {
            var command = _mapper.Map<AddEmployeeToPositionCommand>(employeeForAddingDto);
            command.PositionId = id;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{positionId}/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(Guid positionId, Guid employeeId) =>
            Ok(await Mediator.Send(new DeleteEmployeeFromPosCommand
            {
                PositionId = positionId,
                EmployeeId = employeeId
            }));
    }
}
