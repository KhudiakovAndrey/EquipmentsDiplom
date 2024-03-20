using AutoMapper;
using Equipments.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Queries
{
    public partial class GetUsers
    {
        public class QueryHandler : IRequestHandler<Query, IEnumerable<UserVm>>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;


            public QueryHandler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<UserVm>> Handle(Query request, CancellationToken cancellationToken)
            {
                var entities = await _dbContext.AppUsers.ToListAsync();
                return _mapper.Map<IEnumerable<UserVm>>(entities);
            }
        }
    }
}
