using Equipments.Application.Departments.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DepartmentsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new GetDepartments.Query();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
