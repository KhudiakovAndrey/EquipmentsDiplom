using MediatR;
using System.Collections.Generic;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetAllByPrevMonth
    {
        public class Query : IRequest<IEnumerable<EquipmentTypeDto>>
        {
        }
    }
}
