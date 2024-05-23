using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetCreateRequestByUser
    {
        public class Query : IRequest<int>
        {
            public Guid UserID { get; set; }
        }
    }
}
