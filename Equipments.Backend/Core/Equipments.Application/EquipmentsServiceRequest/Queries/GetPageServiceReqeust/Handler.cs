using AutoMapper;
using Equipments.Application.Interfaces;
using Equipments.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetPageServiceReqeust
    {
        public class Handler : IRequestHandler<Query, PaginatedResult<ServiceRequestVM>>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<PaginatedResult<ServiceRequestVM>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _dbContext.EquipmentServiceRequests.AsQueryable();
                if (request.CreationStartDate != null)
                {
                    query = query.Where(entity => entity.CreationDate >= request.CreationStartDate);
                }
                if (request.CreationEndDate != null)
                {
                    query = query.Where(entity => entity.CreationDate <= request.CreationEndDate);
                }
                if (request.IDResponsible != null)
                {
                    query = query.Where(entity => entity.Idresponsible == request.IDResponsible);
                }
                if (request.IDSystemAdministration != null)
                {
                    query = query.Where(entity => entity.IdsystemAdministrator == request.IDSystemAdministration);
                }

                int countFound = await query.CountAsync(cancellationToken);
                query = query.Skip((request.Pagination.PageNumber - 1) * request.Pagination.PageSize)
                    .Take(request.Pagination.PageSize);
                var items = await query.Include(req => req.IdresponsibleNavigation)
                            .Include(req => req.IdsystemAdministratorNavigation)
                            .Include(req => req.IdproblemTypeNavigation)
                            .ToListAsync(cancellationToken);

                var itemDtos = _mapper.Map<List<ServiceRequestVM>>(items);
                var totalCount = await _dbContext.EquipmentServiceRequests.CountAsync(cancellationToken);

                var paginationResult = new PaginatedResult<ServiceRequestVM>(
                    itemDtos,
                    request.Pagination.PageNumber,
                    request.Pagination.PageSize,
                    totalCount,
                    countFound);

                return paginationResult;

            }
        }
    }
}
