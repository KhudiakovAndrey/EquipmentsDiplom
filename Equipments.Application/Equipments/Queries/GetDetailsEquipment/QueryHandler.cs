using AutoMapper;
using AutoMapper.QueryableExtensions;
using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using Equipments.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Equipments.Queries.GetDetailsEquipment
{
    public partial class GetDetailsEquipment
    {
        public class QueryHandler : IRequestHandler<Query, EquipmentDetailsVm>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public QueryHandler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<EquipmentDetailsVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var equipmentQuery = _dbContext.Equipments
                    .FirstOrDefaultAsync(equipment => equipment.IdEquipment == request.IdEquipment);

                if (equipmentQuery == null)
                {
                    throw new NotFoundException(nameof(Equipment), request.IdEquipment);
                }

                var equipmentDetailsVm = _mapper.Map<EquipmentDetailsVm>(equipmentQuery);

                var inventoryObjectsQuery = await _dbContext.InventoryObjects
                    .Where(inv => inv.IdEquipment == equipmentDetailsVm.IdEquipment)
                    .ProjectTo<InventoryItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                equipmentDetailsVm.InvetoryObjects = inventoryObjectsQuery;
                return equipmentDetailsVm;
            }
        }

    }

}
