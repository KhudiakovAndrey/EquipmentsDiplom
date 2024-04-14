using AutoMapper;
using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using Equipments.Application.Models;
using Equipments.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    .Include(r => r.IdresponsibleNavigation.IddepartmentNavigation)
                    .Include(r => r.IdresponsibleNavigation.IdpostNavigation)
                    .Include(r => r.IdproblemTypeNavigation)
                    .Include(r => r.IdproblemTypeNavigation.IdequipmentTypeNavigation)
                    .Include(r => r.IdsystemAdministratorNavigation)
                    .Include(r => r.IdsystemAdministratorNavigation.IddepartmentNavigation)
                    .Include(r => r.IdsystemAdministratorNavigation.IdpostNavigation)
                    .FirstOrDefaultAsync(r => r.Id == request.ID);

                if (serviceRequest == null)
                {
                    throw new NotFoundException(nameof(EquipmentServiceRequest), request.ID);
                }

                var detailsDto = _mapper.Map<RequestDetailsVM>(serviceRequest);

                var requestStatuses = _dbContext.RequestStatusChanges
                    .Include(s => s.StatusNavigation)
                    .Where(s => s.IdequipmentServiceRequest == request.ID);

                detailsDto.Statues = _mapper.Map<List<Models.RequestDetailsVM>>(requestStatuses);

                return detailsDto;

            }
        }
    }
}
