using AutoMapper;
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
        public class QueryHandler : IRequestHandler<Query, UserVm>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public QueryHandler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<UserVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.AppUsers.FirstOrDefaultAsync(user => user.Id == 1);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(AppUser), request.RowGuid);
                }

                return _mapper.Map<UserVm>(entity);
            }
        }
    }
}
