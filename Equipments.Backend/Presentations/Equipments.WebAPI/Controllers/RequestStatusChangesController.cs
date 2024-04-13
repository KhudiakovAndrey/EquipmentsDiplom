using AutoMapper;
using Equipments.Application.RequestStatusChanges.Commands;
using Equipments.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [ApiController]
    [Route("api/request-status-changes")]
    public class RequestStatusChangesController : BaseController
    {
        private readonly IMapper _mapper;

        public RequestStatusChangesController(IMapper mapper)
        {
            _mapper = mapper;
        }

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

        [HttpPost]
        public async Task<ActionResult> Create(CreateRequestStatusChangeDto model)
        {
            var command = _mapper.Map<CreateRequestStatus.Command>(model);
            var id = await Mediator.Send(command);
            return Ok(id);
        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdateRequestStatusChangeDto model)
        {
            var command = _mapper.Map<UpdateRequestStatus.Command>(model);
            await Mediator.Send(command);
            return Ok();
        }
    }
}
