using Equipments.Application.EquipmentsServiceRequest.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Buffers.Text;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : BaseController
    {
        [Authorize]
        [HttpGet("service-request-details/{id}")]
        public async Task<ActionResult> GetServiceRequestDetailsReport(Guid id)
        {
            var query = new GetServiceRequestReport.Query
            {
                IDRequest = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
