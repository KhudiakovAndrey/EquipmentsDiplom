using AutoMapper;
using Equipments.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentTypes
{
    public partial class GetAllEquipmentType
    {
        public class Handler : IRequestHandler<Query, List<EquipmentTypeDto>>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<List<EquipmentTypeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var types = await _dbContext.EquipmentTypes.Include(type => type.ProblemTypes).ToListAsync();
                var typesDtos = _mapper.Map<List<EquipmentTypeDto>>(types);

                return typesDtos;
            }
        }
    }
}
