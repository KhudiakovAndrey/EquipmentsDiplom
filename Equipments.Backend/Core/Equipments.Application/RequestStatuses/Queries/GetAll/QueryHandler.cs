using AutoMapper;
using Equipments.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.RequestStatuses.Queries
{
    public partial class GetAll
    {
        public class QueryHandler : IRequestHandler<Query, List<RequestStatusDto>>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public QueryHandler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<RequestStatusDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var entitys = await _dbContext.RequestStatuses.ToListAsync(cancellationToken);

                var statusDtos = _mapper.Map<List<RequestStatusDto>>(entitys);
                return statusDtos;
            }
        }
    }
}
