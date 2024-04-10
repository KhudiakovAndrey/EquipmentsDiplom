using AutoMapper;
using Equipments.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.ProblemTypes.Queries
{
    public partial class GetAllProblemType
    {
        public class Handler : IRequestHandler<Query, List<ProblemTypeDto>>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(IEquipmentsDbContext dbContext, IMapper mapper = null)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<ProblemTypeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var problems = await _dbContext.ProblemTypes
                    .Include(p => p.IdequipmentTypeNavigation)
                    .ToListAsync(cancellationToken);

                var problemDtos = _mapper.Map<List<ProblemTypeDto>>(problems);

                return problemDtos;
            }
        }
    }
}
