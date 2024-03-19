
using AutoMapper;
using Equipments.Application.Users.Commands;
using Equipments.Application.Users.Queries;
using Equipments.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUsers.UserVm>>> GetAll()
        {
            var query = new GetUsers.Query();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{guid}")]
        public async Task<ActionResult<GetUserById.UserVm>> GetUser(Guid guid)
        {
            var query = new GetUserById.Query()
            {
                RowGuid = guid
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUser.Command>(createUserDto);
            var userGuid = await Mediator.Send(command);
            return Ok(userGuid);
        }
    }
}
