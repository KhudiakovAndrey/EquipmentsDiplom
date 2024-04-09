using Equipments.Application.Models;
using MediatR;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetPageServiceReqeust
    {
        public class Query : IRequest<PaginatedResult<ServiceRequestVM>>
        {
            public PaginationQuery Pagination { get; set; } = new();
            public Guid? IDResponsible { get; set; }
            public DateTime? CreationDate{ get; set; }
        }
    }
}
