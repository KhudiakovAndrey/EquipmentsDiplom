using AutoMapper;
using Equipments.Application.EquipmentsServiceRequest.Queries;
using Equipments.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetEmployees
    {
        public class Handler : IRequestHandler<Query, List<EmployeDto>>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<EmployeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employees = _dbContext.Employees
                    .Include(em => em.IddepartmentNavigation)
                    .Include(em => em.IdpostNavigation)
                    .ToList();
                var employeDtos = _mapper.Map<List<EmployeDto>>(employees);

                return employeDtos;
            }
        }
    }
}
