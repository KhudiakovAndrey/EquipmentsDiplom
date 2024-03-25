using AutoMapper;
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

namespace Equipments.Application.Equipments.Queries
{
    public partial class GetPageEquipmentsList
    {
        public class QueryHandler : IRequestHandler<Query, PagedListEquipments>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public QueryHandler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<PagedListEquipments> Handle(Query request, CancellationToken cancellationToken)
            {
                var equipments = await _dbContext.Equipments.Include(equip => equip.IdStatusEquipmentNavigation)
                                                            .Include(equip => equip.IdTypeEquipmentNavigation)
                                                            .ToListAsync();

                if (!string.IsNullOrEmpty(request.FilterTitle + request.FilterStatus + request.FilterType) && request.FilterStatus != null)
                {
                    equipments = equipments.Where(equip => Filtered(equip, request)).ToList();
                }

                var equipmentsDtos = _mapper.Map<List<PageItemEquipmentsDto>>(equipments);

                var page = new PagedListEquipments(request.PageNumber, request.PageSize, equipmentsDtos);
                return page;
            }
            private bool Filtered(Equipment equip, Query request)
            {
                bool is1 = equip.Title.ToUpper().Contains(request.FilterTitle.ToUpper());
                bool is2 = request.FilterIsGroup == null ? true : equip.Isgroup == request.FilterIsGroup;
                bool is3 = request.FilterStatus == "Все" ? true : equip.IdStatusEquipmentNavigation.Title.ToUpper() == request.FilterStatus.ToUpper();
                bool is4 = request.FilterType == "Все" ? true : equip.IdTypeEquipmentNavigation.Title.ToUpper() == request.FilterType.ToUpper();
                return is1 && is2 && is3 && is4;
            }
        }
    }
}
