using AutoMapper;
using AutoMapper.QueryableExtensions;
using Equipments.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Equipments.Queries.GetEquipmentList
{
    public partial class GetEquipmentList
    {
        public class QueryHandler : IRequestHandler<Query, EquipmentListVm>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;
            public QueryHandler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<EquipmentListVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var equipmentsQuery = await _dbContext.Equipments
                    .ProjectTo<EquipmentListItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return new EquipmentListVm { Equipments = equipmentsQuery };
            }
        }
    }

}
