using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using Equipments.Application.Models;
using Equipments.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetImage
    {
        public class Handler : IRequestHandler<Query, string>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public Handler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            async Task<string> IRequestHandler<Query, string>.Handle(Query request, CancellationToken cancellationToken)
            {
                var employ = await _dbContext.Employees.FirstOrDefaultAsync(em => em.Iduser == request.ID);
                if (employ == null)
                {
                    throw new NotFoundException(nameof(Employee), request.ID);
                }

                return employ.Photo;
            }
        }
    }
}
