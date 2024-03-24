using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using Equipments.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Commands
{
    public partial class DeleteUser
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
                //var entity = await _dbContext.AppUsers.FirstOrDefaultAsync(user =>
                //    user.Id == request.IdUser, cancellationToken);
                //if (entity == null)
                //{
                //    throw new NotFoundException(nameof(AppUser), request.IdUser);
                //}

                //_dbContext.AppUsers.Remove(entity);
                //await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

        }
    }

}
