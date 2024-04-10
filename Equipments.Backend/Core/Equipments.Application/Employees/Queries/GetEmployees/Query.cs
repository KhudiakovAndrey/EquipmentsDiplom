using Equipments.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetEmployees
    {
        public class Query : IRequest<List<EmployDto>>
        {
        }
    }
}
