using MediatR;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetEvgCreatedRequestByUser
    {
        public class Query : IRequest<double>
        {
            public Guid IDUser { get; set; }
        }
    }
}
