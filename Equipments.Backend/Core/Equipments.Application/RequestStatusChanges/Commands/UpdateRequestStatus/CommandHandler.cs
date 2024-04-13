using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using Equipments.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.RequestStatusChanges.Commands
{
    public partial class UpdateRequestStatus
    {
        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public CommandHandler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.RequestStatusChanges.FindAsync(request.ID, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(RequestStatusChange), request.ID);
                }

                var requestService = await _dbContext.EquipmentServiceRequests.FindAsync(request.IDRequestService, cancellationToken);

                if (requestService == null)
                {
                    throw new NotFoundException(nameof(EquipmentServiceRequest), request.IDRequestService);
                }

                var status = await _dbContext.RequestStatuses.FindAsync(request.IDStatus, cancellationToken);
                if (status == null)
                {
                    throw new NotFoundException(nameof(RequestStatus), request.IDStatus);
                }

                var updateRequestStatusChange = new RequestStatusChange
                {
                    Id = request.ID,
                    IdequipmentServiceRequest = request.IDRequestService,
                    StatusChangeDate = DateTime.Now,
                    WorkDescription = request.Description
                };

                _dbContext.RequestStatusChanges.Update(updateRequestStatusChange);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
