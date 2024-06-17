using Equipments.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetAllByDepartment
    {
        public class Handler : IRequestHandler<Query, EmployeListDto>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public Handler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<EmployeListDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.FromSql<EmployeDto>("SELECT \"FullName\", \"Name\" as PostName, \"Number\" as OfficeNumber\r\nFROM \"Employees\"\r\nJOIN \"Posts\" ON \"Employees\".\"IDPost\" = \"Posts\".\"ID\"\r\nJOIN \"AssignedOffices\" ON \"Employees\".\"IDAssignedOffice\" = \"AssignedOffices\".\"ID\"\r\nWHERE \"IDDepartment\" = @idDepartmant",
                    new { idDepartmant = request.IDDepartment });
                EmployeListDto list = new EmployeListDto { EmployeList = result };
                return list;
            }
        }
    }
}
