using MediatR;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetServiceRequestReport
    {
        public class Query : IRequest<byte[]>
        {
            public Guid IDRequest { get; set; }
        }
    }
}
