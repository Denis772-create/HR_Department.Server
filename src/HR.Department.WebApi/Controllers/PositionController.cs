﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using HR.Department.Core.Commands.Position.AddExistingEmployee;
using HR.Department.Core.Commands.Position.AddNewEmployee;
using HR.Department.Core.Commands.Position.CreatePosition;
using HR.Department.Core.Commands.Position.DeleteEmployee;
using HR.Department.Core.Commands.Position.DeletePosition;
using HR.Department.Core.Commands.Position.UpdatePosition;
using HR.Department.Core.Dto;
using HR.Department.Core.Queries.Position.GetAllTypePositions;
using HR.Department.Core.Queries.Position.GetPositionList;
using HR.Department.WebApi.Filters.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace HR.Department.WebApi.Controllers
{
    public class PositionController : BaseController

    {
        private readonly IMapper _mapper;
        public PositionController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PositionListDto>> GetAll() =>
            Ok(await Mediator.Send(new GetPositionListQuery()));

        [HttpGet("types")]
        public async Task<ActionResult<TypePositionDto>> GetAllTypePositions() =>
            Ok(await Mediator.Send(new GetAllTypePositionsQuery()));

        [HttpPost]
        [Validation]
        public async Task<IActionResult> CreatePosition([FromBody] PositionDto positionDto)
        {
            var command = _mapper.Map<CreatePositionCommand>(positionDto);
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("new/employee")]
        [Validation]
        public async Task<IActionResult> AddNewEmployeeToPosition(
            [FromBody] EmployeeForAddingDto employeeForAddingDto)
        {
            var command = _mapper.Map<AddNewEmployeeToPositionCommand>(employeeForAddingDto);
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{positionId}/{employeeId}")]
        public async Task<IActionResult> AddExistingEmployeeToPosition(Guid positionId,
            Guid employeeId) =>
            Ok(await Mediator.Send(new AddExistingEmployeeCommand
            {
                PositionId = positionId,
                EmployeeId = employeeId
            }));

        [HttpPut]
        [Validation]
        public async Task<IActionResult> UpdatePosition(
            [FromBody] PositionForUpdateDto forUpdateDto)
        {
            var command = _mapper.Map<UpdatePositionCommand>(forUpdateDto);
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(Guid id) =>
            Ok(await Mediator.Send(new DeletePositionCommand() { Id = id }));

        [HttpDelete("{positionId}/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(Guid positionId, Guid employeeId) =>
            Ok(await Mediator.Send(new DeleteEmployeeFromPosCommand
            {
                PositionId = positionId,
                EmployeeId = employeeId
            }));

    }
}
