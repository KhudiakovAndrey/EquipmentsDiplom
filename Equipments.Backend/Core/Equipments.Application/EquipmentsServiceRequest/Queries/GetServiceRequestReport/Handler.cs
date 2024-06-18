using AutoMapper;
using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using Equipments.Application.Reports;
using Equipments.Domain.Entities;
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
    public partial class GetServiceRequestReport
    {
        public class Handler : IRequestHandler<Query, byte[]>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<byte[]> Handle(Query request, CancellationToken cancellationToken)
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
                    .Include(r => r.RequestStatusChanges).ThenInclude(rsc => rsc.StatusNavigation)
                    .FirstOrDefaultAsync(en => en.Id == request.IDRequest);
                if (serviceRequest == null)
                {
                    throw new NotFoundException(nameof(EquipmentServiceRequest), request.IDRequest);
                }
                GetServiceRequestDetails.RequestDetailsVM detailsVM = _mapper.Map<GetServiceRequestDetails.RequestDetailsVM>(serviceRequest);

                var report = new ServiceRequestReport(detailsVM);

                var reportBytes = report.Compose();

                return reportBytes;
            }
        }
    }
}
