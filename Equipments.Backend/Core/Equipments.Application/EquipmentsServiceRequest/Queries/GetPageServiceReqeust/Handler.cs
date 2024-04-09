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
using static Equipments.Application.EquipmentsServiceRequest.Queries.GetPageResponsibleRequest;

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
                var requestQuery = await _dbContext.EquipmentServiceRequests
                    .Where(req =>
                        request.CreationDate == null ? true : req.CreationDate == request.CreationDate
                        && request.IDResponsible == null ? true : req.Idresponsible == request.IDResponsible)
                    .Skip((request.Pagination.PageNumber - 1) * request.Pagination.PageSize)
                    .Take(request.Pagination.PageSize)
                    .ToListAsync(cancellationToken);

                var itemDtos = _mapper.Map<List<ServiceRequestVM>>(requestQuery);
                var totalCount = await _dbContext.EquipmentServiceRequests.CountAsync(cancellationToken);

                var paginationResult = new PaginatedResult<ServiceRequestVM>(
                    itemDtos,
                    request.Pagination.PageNumber,
                    request.Pagination.PageSize,
                    totalCount);

                return paginationResult;

            }
        }
    }
}
