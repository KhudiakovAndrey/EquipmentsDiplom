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
    public partial class GetEvgCreatedRequestByUser
    {
        public class Handler : IRequestHandler<Query, double>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public Handler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<double> Handle(Query request, CancellationToken cancellationToken)
            {
                var employe = await _dbContext.Employees.FirstOrDefaultAsync(em => em.Iduser == request.IDUser);
                if (employe == null)
                {
                    throw new NotFoundException(nameof(Employee), request.IDUser);
                }

                var requests = await _dbContext.EquipmentServiceRequests
                    .Where(req => req.Idresponsible == employe.Id)
                    .OrderBy(req => req.CreationDate)
                    .Select(req => req.CreationDate)
                    .ToListAsync();

                double totalTimeBetweenRequests = 0;
                for (int i = 1; i < requests.Count; i++)
                {
                    TimeSpan timeBetweenRequests = requests[i] - requests[i - 1];
                    totalTimeBetweenRequests += timeBetweenRequests.TotalDays;
                }
                double averageTimeBetweenRequests = totalTimeBetweenRequests / (requests.Count - 1);
                return averageTimeBetweenRequests;
            }
        }
    }
}
