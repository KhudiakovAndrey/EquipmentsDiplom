using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.DataBase
{
    public partial class CanConnect
    {
        public class Query : IRequest<bool>
        {

        }
    }
}
