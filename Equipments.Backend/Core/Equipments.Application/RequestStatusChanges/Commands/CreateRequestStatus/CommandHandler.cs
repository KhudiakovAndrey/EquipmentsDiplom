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
    public partial class CreateRequestStatus
    {
        public class CommandHandler : IRequestHandler<Command, int>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public CommandHandler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var requestService = await _dbContext.EquipmentServiceRequests.FindAsync(new object[] { request.IDRequestService }, cancellationToken);

                if (requestService == null)
                {
                    throw new NotFoundException(nameof(EquipmentServiceRequest), request.IDRequestService);
                }

                var status = await _dbContext.RequestStatuses.FindAsync(new object[] { request.IDStatus }, cancellationToken);
                if (status == null)
                {
                    throw new NotFoundException(nameof(RequestStatus), request.IDStatus);
                }

                var newChangeStatus = new RequestStatusChange
                {
                    IdequipmentServiceRequest = request.IDRequestService,
                    Status = request.IDStatus,
                    StatusChangeDate = DateTime.Now,
                    WorkDescription = request.Description
                };

                _dbContext.RequestStatusChanges.Add(newChangeStatus);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return newChangeStatus.Id;
            }
        }
    }
}
