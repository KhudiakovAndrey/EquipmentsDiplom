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

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetCreateRequestByUser
    {
        public class Handler : IRequestHandler<Query, int>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public Handler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<int> Handle(Query request, CancellationToken cancellationToken)
            {
                var employe = await _dbContext.Employees.FirstOrDefaultAsync(model => model.Iduser == request.UserID, cancellationToken);

                if (employe == null)
                {
                    throw new NotFoundException(nameof(Employee), request.UserID);
                }

                var countCreatedRequest = await _dbContext.EquipmentServiceRequests
                    .CountAsync(req => req.Idresponsible == employe.Id);

                return countCreatedRequest;
            }
        }
    }
}
