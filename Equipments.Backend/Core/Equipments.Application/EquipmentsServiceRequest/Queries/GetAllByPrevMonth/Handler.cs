using Equipments.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetAllByPrevMonth
    {
        public class Handler : IRequestHandler<Query, IEnumerable<EquipmentTypeDto>>
        {
            private readonly IEquipmentsDbContext _dbContext;

            public Handler(IEquipmentsDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<IEnumerable<EquipmentTypeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.FromSql<EquipmentTypeDto>("SELECT et.\"Name\" AS \"EquipmentType\", COUNT(*) AS \"RequestCount\"\r\nFROM \"EquipmentServiceRequest\" esr\r\nJOIN \"ProblemTypes\" pt ON esr.\"IDProblemType\" = pt.\"ID\"\r\nJOIN \"EquipmentTypes\" et ON pt.\"IDEquipmentType\" = et.\"ID\"\r\nWHERE esr.\"CreationDate\" >= DATE_TRUNC('day', NOW()) - INTERVAL '1 month'\r\nGROUP BY et.\"Name\";\r\n");
                return result;
            }
        }
    }
}
