using Equipments.Application.EquipmentsServiceRequest.Queries;
using MediatR;
using System.Collections.Generic;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetEmployees
    {
        public class Query : IRequest<List<EmployeDto>>
        {
        }
    }
}
