using Equipments.Application.Employees.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new GetEmployees.Query();
            var vm = Mediator.Send(query);

            return Ok(vm);
        }
    }
}
