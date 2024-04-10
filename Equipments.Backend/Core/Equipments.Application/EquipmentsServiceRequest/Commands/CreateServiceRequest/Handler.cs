using Equipments.Application.Interfaces;
using Equipments.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentsServiceRequest.Commands
{
    public partial class CreateServiceRequest
    {
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public Handler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var problemTypes = await _dbContext.ProblemTypes
                    .Include(p => p.IdequipmentTypeNavigation)
                    .ToListAsync(cancellationToken);

                var type = problemTypes.FirstOrDefault(p => p.IdequipmentTypeNavigation.Name == request.EquipmentType && p.Description == request.ProblemType);

                if (type == null)
                    return Guid.Empty;


                var req = new EquipmentServiceRequest
                {
                    Idresponsible = request.IDResponsible,
                    IdsystemAdministrator = request.IDSystemAdministrator,
                    IdproblemType = type.Id,
                    DetailedDescription = request.DetailedDescription,
                    BrokenEquipmentDescription = request.BrokenEquipmentDescription,
                    CreationDate = DateTime.Now,
                };

                _dbContext.EquipmentServiceRequests.Add(req);

                var changeStatuseRequest = new RequestStatusChange
                {
                    IdequipmentServiceRequest = req.Id,
                    StatusChangeDate = DateTime.Now,
                    Status = 4, //В обработке
                    WorkDescription = "Заявка была успешно создана, прямо сейчас она находится в обработке чтобы исполнитель мог приняться за работу"
                };

                _dbContext.RequestStatusChanges.+ Add(changeStatuseRequest);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return req.Id;
            }
        }
    }
}
