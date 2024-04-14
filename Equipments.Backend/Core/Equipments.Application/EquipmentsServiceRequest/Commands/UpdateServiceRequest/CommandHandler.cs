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

namespace Equipments.Application.EquipmentsServiceRequest.Commands
{
    public partial class UpdateServiceRequest
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
                var entity = await _dbContext.EquipmentServiceRequests.FindAsync(new object[] { request.ID }, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(EquipmentServiceRequest), request.ID);
                }

                var responsible = await _dbContext.Employees.FindAsync(new object[] { request.IDResponsible }, cancellationToken);

                if (responsible == null)
                {
                    throw new NotFoundException(nameof(Employee), request.IDResponsible);
                }

                var sysAdmin = await _dbContext.Employees.FindAsync(new object[] { request.IDSystemAdministration }, cancellationToken);

                if (sysAdmin == null)
                {
                    throw new NotFoundException(nameof(Employee), request.IDSystemAdministration);
                }

                var problemType = await _dbContext.ProblemTypes.FirstOrDefaultAsync(problem =>
                    problem.Description == request.ProblemType &&
                    problem.IdequipmentTypeNavigation.Name == request.EquipmentType);

                if (problemType == null)
                {
                    throw new NotFoundException(nameof(ProblemType), "{null}");
                }

                entity.Idresponsible = request.IDResponsible;
                entity.IdsystemAdministrator = request.IDSystemAdministration;
                entity.IdproblemType = problemType.Id;
                entity.DetailedDescription = request.Description;
                entity.BrokenEquipmentDescription = request.BrokenEquipmentDescription;
                entity.CreationDate = DateTime.Now;

                _dbContext.EquipmentServiceRequests.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
