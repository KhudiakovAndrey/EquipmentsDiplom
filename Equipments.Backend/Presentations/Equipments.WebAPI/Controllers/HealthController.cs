using Equipments.Application.DataBase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : BaseController
    {
        [HttpGet("status")]
        public async Task<ActionResult> Status()
        {
            if (!await CheckDataBaseConnection())
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, "DataBase connection failed");
            }
            return Ok("Server is working");
        }

        private async Task<bool> CheckDataBaseConnection()
        {
            var query = new CanConnect.Query();
            var isConnect = await Mediator.Send(query);
            return isConnect;
        }


    }
}
