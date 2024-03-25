using AutoMapper;
using Equipments.Application.Equipments.Commands;
using Equipments.Application.Equipments.Queries;
using Equipments.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : BaseController
    {
        private readonly IMapper _mapper;

        public EquipmentsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("page")]
        public async Task<ActionResult<GetPageEquipmentsList.PagedListEquipments>> GetPage([FromQuery] GetPageEquipmentsDto dto)
        {
            var query = _mapper.Map<GetPageEquipmentsList.Query>(dto);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateEquipmentDto dto)
        {
            var command = _mapper.Map<AddEquipment.Command>(dto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }
    }
}
