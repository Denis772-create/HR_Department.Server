using System.Threading.Tasks;
using HR.Department.WebApi.Features.Position.Queries.GetPositionList;
using HR.Department.WebApi.Modes;
using Microsoft.AspNetCore.Mvc;

namespace HR.Department.WebApi.Controllers
{
    public class PositionController : BaseController

    {
        [HttpGet]
        public async Task<ActionResult<PositionListVm>> GetAll() =>
            Ok(await Mediator.Send(new GetPositionListQuery()));
    }
}
