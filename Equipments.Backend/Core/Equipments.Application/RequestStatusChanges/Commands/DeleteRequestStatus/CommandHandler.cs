using Equipments.Application.Common.Exceptions;
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

namespace Equipments.Application.RequestStatusChanges.Commands
{
    public partial class DeleteRequestStatus
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

                var entitys = await _dbContext.RequestStatusChanges.Where(status => status.IdequipmentServiceRequest == entity.IdequipmentServiceRequest)
                    .OrderBy(status => status.StatusChangeDate)
                    .ToListAsync(cancellationToken);

                var lastEntity = entitys.LastOrDefault();

                if (lastEntity == null || lastEntity!.Id != request.ID)
                {
                    throw new NotFoundException(nameof(RequestStatusChange), request.ID);
                }

                _dbContext.RequestStatusChanges.Remove(lastEntity);
                await _dbContext.SaveChangesAsync(cancellationToken);


                return Unit.Value;
            }
        }
    }
}
