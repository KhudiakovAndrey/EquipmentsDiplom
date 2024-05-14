using AutoMapper;
using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using Equipments.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;
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
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;
            public Handler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<EmployeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.Iduser == request.IDUser);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Employee), request.IDUser);
                }

                var employeDto = _mapper.Map<EmployeDto>(entity);
                return employeDto;
            }
        }
    }
}
