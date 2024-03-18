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

namespace Equipments.Application.Users.Queries
{
    public partial class GetUserById
    {
        public class QueryHandler : IRequestHandler<Query, User>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public QueryHandler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var enity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Rowguid == request.RowGuid);
                if (enity == null)
                {
                    throw new NotFoundException(nameof(User), request.RowGuid);
                }
                return enity;
            }
        }
    }
}
