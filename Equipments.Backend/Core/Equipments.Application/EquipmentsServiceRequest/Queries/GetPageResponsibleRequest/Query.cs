using Equipments.Application.Models;
using MediatR;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetPageResponsibleRequest
    {
        public class Query : IRequest<PaginatedResult<RequestVm>>
        {
            public PaginationQuery Pagination { get; set; } = new();
            public Guid IDResponsible { get; set; }
            public Guid? IDSystemAdministrator { get; set; }
            public DateTime? CreationDate { get; set; }

        }
    }
}
