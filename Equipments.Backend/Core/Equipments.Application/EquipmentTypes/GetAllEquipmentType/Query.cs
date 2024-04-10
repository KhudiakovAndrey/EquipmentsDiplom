using MediatR;
using System.Collections.Generic;

namespace Equipments.Application.EquipmentTypes
{
    public partial class GetAllEquipmentType
    {
        public class Query : IRequest<List<EquipmentTypeDto>>
        {
        }
    }
}
