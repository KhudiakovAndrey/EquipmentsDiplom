using AutoMapper;
using Equipments.Application.Common.Exceptions;
using Equipments.Application.EquipmentsServiceRequest.Queries;
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

namespace Equipments.Application.Employees.Queries
{
    public partial class GetEmployeeByID
    {
        public class Handler : IRequestHandler<Query, EmployeDto>
        {
            private readonly IMapper _mapper;
            private readonly IEquipmentsDbContext _dbContext;

            public Handler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<EmployeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.Employees.Include(x => x.IdpostNavigation)
                                       .Include(x => x.IddepartmentNavigation)
                                       .Include(x => x.IdassignedOfficeNavigation)
                                       .FirstOrDefaultAsync(employee => employee.Id == request.IDEmployee);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Employee), request.IDEmployee);
                }

                var employeDto = _mapper.Map<EmployeDto>(entity);
                return employeDto;

            }
        }
    }
}
