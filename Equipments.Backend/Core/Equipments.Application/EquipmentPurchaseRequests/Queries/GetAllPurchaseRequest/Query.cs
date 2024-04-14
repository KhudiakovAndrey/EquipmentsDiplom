using MediatR;

namespace Equipments.Application.EquipmentPurchaseRequests.Queries
{
    public partial class GetAllPurchaseRequest
    {
        public class Query : IRequest<PurchaseRequestsVm>
        {
        }
    }
}
