using MediatR;
using System;

namespace Equipments.Application.EquipmentPurchaseRequests.Queries
{
    public partial class GetPurchaseRequestDetail
    {
        public class Query : IRequest<PurchaseRequestDetailDto>
        {
            public Guid ID { get; set; }
        }
    }
}
