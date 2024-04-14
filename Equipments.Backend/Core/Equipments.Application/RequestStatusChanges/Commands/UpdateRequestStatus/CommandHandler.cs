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
                var entity = await _dbContext.RequestStatusChanges.FindAsync(new object[] { request.ID }, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(RequestStatusChange), request.ID);
                }

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


                entity.Id = request.ID;
                entity.IdequipmentServiceRequest = request.IDRequestService;
                entity.Status = request.IDStatus;
                entity.StatusChangeDate = DateTime.Now;
                entity.WorkDescription = request.Description;

                _dbContext.RequestStatusChanges.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
