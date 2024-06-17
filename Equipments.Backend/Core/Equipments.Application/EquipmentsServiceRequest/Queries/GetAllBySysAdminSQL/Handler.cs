using Equipments.Application.Interfaces;
using Equipments.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetAllBySysAdminSQL
    {
        public class Handler : IRequestHandler<Query, ServiceRequestListDto>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public Handler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ServiceRequestListDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.FromSql<ServiceRequestDto>($"SELECT \"BrokenEquipmentDescription\", \"Status\", MAX(\"StatusChangeDate\") as LastStatusChangeDate\r\nFROM \"EquipmentServiceRequest\"\r\nJOIN \"RequestStatusChange\" ON \"EquipmentServiceRequest\".\"ID\" = \"RequestStatusChange\".\"IDEquipmentServiceRequest\"\r\nWHERE \"IDSystemAdministrator\" = @idSysAdmin \r\nGROUP BY \"BrokenEquipmentDescription\", \"Status\";\r\n", new { idSysAdmin = request.IDSystemAdmin });
                await Task.Delay(0);
                //var dto = new ServiceRequestListDto { Items = result };
                return new ServiceRequestListDto();
            }
        }
    }
}
