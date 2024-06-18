using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetAllByDepartment
    {
        public class Query : IRequest<IEnumerable<EmployeDto>>
        {
            public int IDDepartment { get; set; }
        }
    }
}
