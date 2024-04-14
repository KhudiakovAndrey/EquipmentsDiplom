using Equipments.Application.EquipmentPurchaseRequests.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/purchase-requests")]
    public class EquipmentPurchaseRequestsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new GetAllPurchaseRequest.Query();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
