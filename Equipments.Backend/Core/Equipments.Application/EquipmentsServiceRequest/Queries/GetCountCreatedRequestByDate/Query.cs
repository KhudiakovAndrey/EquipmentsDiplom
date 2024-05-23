using MediatR;
using System;
using System.Collections.Generic;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetCountCreatedRequestByDate
    {
        public class Query : IRequest<List<RequestCountDateDto>>
        {
            public Guid IDUser { get; set; }
            public RequestCountPeriod Period { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
    }
}
