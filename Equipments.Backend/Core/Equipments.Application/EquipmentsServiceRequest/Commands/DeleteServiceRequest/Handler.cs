using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentsServiceRequest.Commands
{
    public partial class DeleteServiceRequest
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public Handler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.EquipmentServiceRequests
                    .FindAsync(new object[] { request.ID }, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(EquipmentsServiceRequest), request.ID);
                }

                _dbContext.EquipmentServiceRequests.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
