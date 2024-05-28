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

namespace Equipments.Application.Employees.Commands
{
    public partial class ChangeImage
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
                var entity = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == request.ID, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Employee), request.ID);
                }

                entity.Photo = request.Image;
                _dbContext.Employees.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
