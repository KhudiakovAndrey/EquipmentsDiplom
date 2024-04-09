using MediatR;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetServiceRequestDetails
    {
        public class Query : IRequest<RequestDetailsVM>
        {
            public Guid ID { get; set; }
        }
    }
}
