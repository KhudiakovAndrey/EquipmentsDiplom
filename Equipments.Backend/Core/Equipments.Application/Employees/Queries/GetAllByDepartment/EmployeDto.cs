namespace Equipments.Application.Employees.Queries
{
    public partial class GetAllByDepartment
    {
        public class EmployeDto
        {
            public string FullName { get; set; }
            public string PostName { get; set; }
            public string OfficeNumber { get; set; }
        }
    }
}
