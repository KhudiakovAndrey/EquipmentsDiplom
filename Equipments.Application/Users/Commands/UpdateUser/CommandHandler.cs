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

namespace Equipments.Application.Users.Commands
{
    public partial class UpdateUser
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
                
                if( !await _dbContext.Workers.AnyAsync(worker =>
                    worker.Idworker == request.Idworker,cancellationToken))
                {
                    throw new NotFoundException(nameof(Worker), request.Idworker);
                }

                var entity = await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Iduser == request.Iduser, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(User), request.Iduser);
                }

                entity.Userlogin = request.Userlogin;
                entity.Userpassword = request.Userpassword;
                entity.Email = request.Email;
                entity.Isactive = request.Isactive;
                entity.Idworker = request.Idworker;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

    }
}
