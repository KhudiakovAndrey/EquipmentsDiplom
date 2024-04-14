using AutoMapper;
using Equipments.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentPurchaseRequests.Queries
{
    public partial class GetAllPurchaseRequest
    {
        public class QueryHandler : IRequestHandler<Query, PurchaseRequestsVm>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public QueryHandler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<PurchaseRequestsVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entities = await _dbContext.EquipmentPurchaseRequests.ToListAsync(cancellationToken);

                var requestVm = new PurchaseRequestsVm
                {
                    TotalCount = entities.Count,
                    Items = _mapper.Map<List<PurchaseRequestItemVm>>(entities)
                };

                return requestVm;
            }
        }
    }
}
