using AutoMapper;
using Equipments.Application.EquipmentsServiceRequest.Commands;
using Equipments.Application.EquipmentsServiceRequest.Queries;
using Equipments.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/service-request")]
    public class EquipmentsServiceRequestController : BaseController
    {
        private readonly IMapper _mapper;

        public EquipmentsServiceRequestController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("page")]
        public async Task<ActionResult> GetPage([FromQuery] GetPageServiceRequestDto model)
        {
            var query = _mapper.Map<GetPageServiceReqeust.Query>(model);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("page/responsible/")]
        public async Task<ActionResult> GetPageResponsible([FromQuery] GetPageResponsibleServiceRequestDto model)
        {
            var query = _mapper.Map<GetPageResponsibleRequest.Query>(model);
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var query = new GetServiceRequestDetails.Query
            {
                ID = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult> CreateServiceRequest([FromBody] CreateServiceRequestDto createServiceRequestDto)
        {
            var command = _mapper.Map<CreateServiceRequest.Command>(createServiceRequestDto);
            var reqId = await Mediator.Send(command);
            return Ok(reqId);
        }
    }
}
