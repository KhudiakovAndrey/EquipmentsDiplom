using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Queries
{
    public partial class GetUserByLoginAndPassword
    {
        public class Query : IRequest<UserVm>
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}
