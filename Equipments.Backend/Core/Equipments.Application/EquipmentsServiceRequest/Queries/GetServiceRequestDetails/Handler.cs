using AutoMapper;
using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using Equipments.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetServiceRequestDetails
    {
        public class Handler : IRequestHandler<Query, RequestDetailsVM>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<RequestDetailsVM> Handle(Query request, CancellationToken cancellationToken)
            {
                var serviceRequest = await _dbContext.EquipmentServiceRequests
                    .Include(r => r.IdresponsibleNavigation)
                    .Include(r => r.IdproblemTypeNavigation)
                    .Include(r => r.IdsystemAdministratorNavigation)
                    .Include(r => r.RequestStatusChanges)
                    .FirstOrDefaultAsync(r => r.Id == request.ID);

                if (serviceRequest == null)
                {
                    throw new NotFoundException(nameof(EquipmentServiceRequest), request.ID);
                }

                var detailsDto = _mapper.Map<RequestDetailsVM>(serviceRequest);

                return detailsDto;

            }
        }
    }
}
