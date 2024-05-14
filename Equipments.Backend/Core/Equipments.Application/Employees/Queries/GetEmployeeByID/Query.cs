using MediatR;
using System;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetEmployeeByID
    {
        public class Query : IRequest<EmployeDto>
        {
            public Guid IDUser { get; set; }
        }
    }
}
