using MediatR;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Equipments.Application.Departments.Queries
{
    public partial class GetDepartments
    {
        public class Query : IRequest<IEnumerable<DepartmentDto>>
        {
        }
    }
}
