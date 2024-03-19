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
                var entity = await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Iduser == request.IdUser, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(User), request.IdUser);
                }

                _dbContext.Users.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

        }
    }

}
