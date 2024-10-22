﻿
using AutoMapper;
using Equipments.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserVm>>> GetAll()
        //{
        //    var query = new GetUsers.Query();
        //    var vm = await Mediator.Send(query);
        //    return Ok(vm);
        //}
        //[HttpGet("{guid}")]
        //public async Task<ActionResult<UserVm>> GetUser(Guid guid)
        //{
        //    var query = new GetUserById.Query()
        //    {
        //        RowGuid = guid
        //    };
        //    var vm = await Mediator.Send(query);
        //    return Ok(vm);
        //}
        //[HttpPost]
        //public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto)
        //{
        //    var command = _mapper.Map<CreateUser.Command>(createUserDto);
        //    var userGuid = await Mediator.Send(command);
        //    return Ok(userGuid);
        //}
    }
}
