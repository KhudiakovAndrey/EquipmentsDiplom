using Equipments.Application.RequestStatuses.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/request-statuses")]
    public class RequestStatusesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new GetAll.Query();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
