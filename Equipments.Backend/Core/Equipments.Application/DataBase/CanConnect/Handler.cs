using Equipments.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.DataBase
{
    public partial class CanConnect
    {
        public class Handler : IRequestHandler<Query, bool>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public Handler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.CheckConnectionAsync();
            }
        }
    }
}
