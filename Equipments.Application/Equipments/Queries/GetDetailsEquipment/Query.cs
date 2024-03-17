using MediatR;

namespace Equipments.Application.Equipments.Queries.GetDetailsEquipment
{
    public partial class GetDetailsEquipment
    {
        public class Query : IRequest<EquipmentDetailsVm>
        {
            public int IdEquipment { get; set; }

        }
    }
}
