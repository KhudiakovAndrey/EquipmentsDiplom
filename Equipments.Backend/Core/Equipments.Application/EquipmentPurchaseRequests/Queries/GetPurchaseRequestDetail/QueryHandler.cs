using AutoMapper;
using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using Equipments.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentPurchaseRequests.Queries
{
    public partial class GetPurchaseRequestDetail
    {
        public class QueryHandler : IRequestHandler<Query, PurchaseRequestDetailDto>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public QueryHandler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<PurchaseRequestDetailDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.EquipmentPurchaseRequests.FindAsync(new object[] { request.ID }, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(EquipmentPurchaseRequest), request.ID);
                }

                var detailedDto = _mapper.Map<PurchaseRequestDetailDto>(entity);

                return detailedDto;
            }
        }
    }
}
