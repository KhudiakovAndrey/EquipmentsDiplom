using System.Collections.Generic;
using System.Linq;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetAllByDepartment
    {
        public class EmployeListDto
        {
            public IEnumerable<EmployeDto> EmployeList { get; set; }
            public int Count => EmployeList.Count();
        }
    }
}
