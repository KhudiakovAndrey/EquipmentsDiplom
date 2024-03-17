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

namespace Equipments.Application.Users.Commands.UpdateUser
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

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Iduser == request.Iduser, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(User), request.Iduser);
                }

                entity.Userlogin = request.Userlogin;
                entity.Userpassword = request.Userpassword;
                entity.Email = request.Email;
                entity.Datelastlogin = request.Datelastlogin;
                entity.Dateregistration = request.Dateregistration;
                entity.Isregemailactive = request.Isregemailactive;
                entity.Isactive = request.Isactive;
                entity.Rowguid = request.Rowguid;
                entity.Idworker = request.Idworker;

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

    }
}
