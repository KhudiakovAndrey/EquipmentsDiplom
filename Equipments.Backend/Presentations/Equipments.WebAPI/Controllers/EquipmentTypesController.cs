using Equipments.Application.EquipmentTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/equipment-types")]
    public class EquipmentTypesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new GetAllEquipmentType.Query();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
