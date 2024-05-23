using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using Equipments.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Equipments.Application.EquipmentsServiceRequest.Queries.GetPageResponsibleRequest;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetCountCreatedRequestByDate
    {
        public class Handler : IRequestHandler<Query, List<RequestCountDateDto>>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public Handler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<List<RequestCountDateDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employe = await _dbContext.Employees.FirstOrDefaultAsync(em => em.Iduser == request.IDUser, cancellationToken);
                if (employe == null)
                {
                    throw new NotFoundException(nameof(Employee), request.IDUser);
                }


                var query = _dbContext.EquipmentServiceRequests.AsQueryable();

                query = query.Where(req => req.CreationDate.Date >= request.StartDate.Date && req.CreationDate.Date <= request.EndDate.Date);


                IQueryable<RequestCountDateDto>? countResult = null;

                switch (request.Period)
                {
                    case RequestCountPeriod.Day:
                        countResult = query.GroupBy(req => req.CreationDate.Date)
                            .Select(g => new RequestCountDateDto(g.Key.ToShortDateString(), g.Count()));
                        break;
                    case RequestCountPeriod.Month:
                        countResult = query.GroupBy(req => new { req.CreationDate.Year, req.CreationDate.Month })
                            .Select(g => new RequestCountDateDto(DateTimeFormatInfo.CurrentInfo.MonthNames[g.Key.Month - 1] + " " + g.Key.Year, g.Count()));
                        break;

                    case RequestCountPeriod.Year:
                        countResult = query.GroupBy(req => req.CreationDate.Year)
                            .Select(g => new RequestCountDateDto(g.Key.ToString(), g.Count()));
                        break;
                    default:

                        break;
                }

                if (countResult == null)
                {
                    return new List<RequestCountDateDto>();
                }

                return await countResult.ToListAsync();
            }
        }
    }
}
