using Equipments.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Queries
{
    public partial class GetUserById
    {
        public class Query : IRequest<UserVm>
        {
            public Guid RowGuid { get; set; }
        }
    }
}
