using System;
using System.Threading.Tasks;
using HR.Department.Core.Entities;
using HR.Department.WebApi.Modes;
using Microsoft.AspNetCore.Mvc;

namespace HR.Department.WebApi.Controllers
{
    public class EmployeeController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<EmployeeListVm>> GetByIdPosition([FromQuery] Guid id) =>
        Ok(await Mediator.Send())
    }
}
