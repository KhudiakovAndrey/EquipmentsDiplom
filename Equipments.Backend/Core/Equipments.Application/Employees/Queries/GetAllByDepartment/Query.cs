using MediatR;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetAllByDepartment
    {
        public class Query : IRequest<EmployeListDto>
        {
            public int IDDepartment { get; set; }
        }
    }
}
