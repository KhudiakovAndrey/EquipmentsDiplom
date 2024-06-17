using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetAllBySysAdminSQL
    {
        public class ServiceRequestListDto
        {
            public List<ServiceRequestDto> Items { get; set; }
            public int Count => Items.Count();
        }
    }
}
