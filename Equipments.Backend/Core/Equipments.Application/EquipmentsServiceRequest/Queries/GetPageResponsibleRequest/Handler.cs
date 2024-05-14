using AutoMapper;
using Equipments.Application.Interfaces;
using Equipments.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetPageResponsibleRequest
    {
        public class Handler : IRequestHandler<Query, PaginatedResult<RequestVm>>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<PaginatedResult<RequestVm>> Handle(Query request, CancellationToken cancellationToken)
            {
                var requestQuery = await _dbContext.EquipmentServiceRequests
                    .Where(req =>
                        request.CreationDate == null ? true : req.CreationDate == request.CreationDate
                        && request.IDSystemAdministrator == null ? true : req.IdsystemAdministrator == request.IDSystemAdministrator)
                    .Skip((request.Pagination.PageNumber - 1) * request.Pagination.PageSize)
                    .Take(request.Pagination.PageSize)
                    .ToListAsync(cancellationToken);

                var itemDtos = _mapper.Map<List<RequestVm>>(requestQuery);
                var totalCount = await _dbContext.EquipmentServiceRequests.CountAsync(cancellationToken);

                var paginationResult = new PaginatedResult<RequestVm>(
                    itemDtos,
                    request.Pagination.PageNumber,
                    request.Pagination.PageSize,
                    totalCount,
                    itemDtos.Count);

                return paginationResult;
            }
        }
    }
}
