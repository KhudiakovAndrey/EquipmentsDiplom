using System.Collections.Generic;

namespace Equipments.Application.EquipmentPurchaseRequests.Queries
{
    public partial class GetAllPurchaseRequest
    {
        public class PurchaseRequestsVm
        {
            public int TotalCount { get; set; }
            public List<PurchaseRequestItemVm> Items { get; set; }
        }
    }
}
