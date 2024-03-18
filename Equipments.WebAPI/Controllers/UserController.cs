
using Equipments.Application.Users.Queries;
using Equipments.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUsers.UserVm>>> GetAll()
        {
            var query = new GetUsers.Query();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("guid")]
        public async Task<ActionResult<User>> GetUserByGuid(Guid guid)
        {
            var query = new GetUserById.Query()
            {
                RowGuid = guid
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
