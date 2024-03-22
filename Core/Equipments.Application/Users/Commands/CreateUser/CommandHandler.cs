using Equipments.Domain.Entities;
using Equipments.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Equipments.Application.Common.Exceptions;

namespace Equipments.Application.Users.Commands
{
    public partial class CreateUser
    {
        public class CommandHandler
            : IRequestHandler<Command, Guid>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public CommandHandler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                //if (await _dbContext.AppUsers.AnyAsync(user =>
                //     user.Email == request.Email, cancellationToken))
                //{
                //    throw new NotFoundException(nameof(AppUser), request.Email);
                //}
                //var user = new AppUser()
                //{
                //UserName = request.Userlogin,
                //pas = request.Userpassword,
                //Email = request.Email,
                //Datelastlogin = null,
                //Dateregistration = DateTime.Now,
                //Isregemailactive = false,
                //Isactive = true,
                //Rowguid = Guid.NewGuid(),
                //Idworker = null
                //};
                //await _dbContext.AppUsers.AddAsync(user, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Guid.NewGuid();
            }
        }
    }
}
