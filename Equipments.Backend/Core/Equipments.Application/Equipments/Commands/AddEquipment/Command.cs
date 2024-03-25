using MediatR;

namespace Equipments.Application.Equipments.Commands
{
    public partial class AddEquipment
    {
        public class Command : IRequest
        {
            public string Title { get; set; } = string.Empty;
            public string FullTitle { get; set; } = string.Empty;
            public bool IsGroup { get; set; }
            public int IdStatus { get; set; }
            public int IdType { get; set; }
        }
    }
}
