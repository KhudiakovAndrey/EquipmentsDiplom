using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Queries
{
    public partial class GetUsers
    {
        public class Query : IRequest<IEnumerable<UserVm>>
        {

        }

    }

}
