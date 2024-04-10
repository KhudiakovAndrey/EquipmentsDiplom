using Equipments.Application.ProblemTypes.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/problem-type")]
    public class ProblemTypesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new GetAllProblemType.Query();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
