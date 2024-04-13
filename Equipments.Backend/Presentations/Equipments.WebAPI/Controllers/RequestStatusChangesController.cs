using Equipments.Application.RequestStatusChanges.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/request-status-changes")]
    public class RequestStatusChangesController : BaseController
    {
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteRequestStatus.Command
            {
                ID = id
            };

            await Mediator.Send(command);
            return Ok();
        }
    }
}
