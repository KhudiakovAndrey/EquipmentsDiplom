using MediatR;

namespace Equipments.Application.Equipments.Queries
{
    public partial class GetPageEquipmentsList
    {
        public class Query : IRequest<PagedListEquipments>
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public string FilterTitle { get; set; } = string.Empty;
            public bool? FilterIsGroup { get; set; }
            public string FilterStatus { get; set; } = string.Empty;
            public string FilterType { get; set; } = string.Empty;
        }
    }
}
