using MediatR;
using System;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetImage
    {
        public class Query : IRequest<string>
        {
            public Guid ID { get; set; }
        }
    }
}
