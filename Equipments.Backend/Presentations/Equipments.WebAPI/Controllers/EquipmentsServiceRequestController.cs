using AutoMapper;
using Equipments.Application.EquipmentsServiceRequest.Commands;
using Equipments.Application.EquipmentsServiceRequest.Queries;
using Equipments.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("page")]
        public async Task<ActionResult> GetPage(GetPageServiceRequestDto model)
        {
            try
            {
                var query = _mapper.Map<GetPageServiceReqeust.Query>(model);
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + ": " + ex.Message);
                return StatusCode(500);
            }
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteServiceRequest(Guid id)
        {
            var command = new DeleteServiceRequest.Command
            {
                ID = id
            };
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateServiceRequestDto dto)
        {
            var command = _mapper.Map<UpdateServiceRequest.Command>(dto);
            await Mediator.Send(command);

            return Ok();
        }

        [Authorize]
        [HttpGet("dashboard/createdCount")]
        public async Task<ActionResult> GetCreatedRequestByUser()
        {

            var query = new GetCreateRequestByUser.Query
            {
                UserID = UserGuid
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [Authorize]
        [HttpGet("dashboard/avgCreatedCount")]
        public async Task<ActionResult> GetAvgCreatedRequestByUser()
        {
            var query = new GetEvgCreatedRequestByUser.Query
            {
                IDUser = UserGuid
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [Authorize]
        [HttpGet("dashboard/countCreatedDate")]
        public async Task<ActionResult> GetCountCreatedServiceRequestByDate([FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate,
            [FromQuery] GetCountCreatedRequestByDate.RequestCountPeriod period)
        {
            var query = new GetCountCreatedRequestByDate.Query
            {
                IDUser = UserGuid,
                StartDate = startDate,
                EndDate = endDate,
                Period = period
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
