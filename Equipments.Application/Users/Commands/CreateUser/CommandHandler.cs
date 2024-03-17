using Equipments.Domain.Entities;
using Equipments.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Commands.CreateUser
{
    public partial class CreateUser
    {
        public class CommandHandler
            : IRequestHandler<Command, int>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public CommandHandler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = new User()
                {
                    Iduser = request.Iduser,
                    Userlogin = request.Userlogin,
                    Userpassword = request.Userpassword,
                    Email = request.Email,
                    Datelastlogin = null,
                    Dateregistration = DateTime.Now,
                    Isregemailactive = false,
                    Isactive = true,
                    Rowguid = Guid.NewGuid(),
                    Idworker = null
                };
                await _dbContext.Users.AddAsync(user, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return user.Iduser;
            }
        }
    }
}
