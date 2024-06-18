using AutoMapper;
using Equipments.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Departments.Queries
{
    public partial class GetDepartments
    {
        public class Handler : IRequestHandler<Query, IEnumerable<DepartmentDto>>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DepartmentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.Departments.ToListAsync();
                var departmentsDto = _mapper.Map<IEnumerable<DepartmentDto>>(result);
                return departmentsDto;
            }
        }
    }
}
