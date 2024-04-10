using AutoMapper;
using Equipments.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Equipments.Application.Models;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetEmployees
    {
        public class Handler : IRequestHandler<Query, List<EmployDto>>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<EmployDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employees = await _dbContext.Employees
                    .Include(em => em.IdpostNavigation)
                    .Include(em => em.IddepartmentNavigation)
                    .ToListAsync(cancellationToken);
                var employeDtos = _mapper.Map<List<EmployDto>>(employees);

                return employeDtos;
            }
        }
    }
}
