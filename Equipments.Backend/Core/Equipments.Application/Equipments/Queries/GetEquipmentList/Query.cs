using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Equipments.Queries.GetEquipmentList
{
    public partial class GetEquipmentList
    {
        public class Query : IRequest<EquipmentListVm>
        {

        }
    }

}
