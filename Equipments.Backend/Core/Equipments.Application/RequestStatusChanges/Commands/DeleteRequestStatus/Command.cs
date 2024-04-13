using MediatR;

namespace Equipments.Application.RequestStatusChanges.Commands
{
    public partial class DeleteRequestStatus
    {
        public class Command : IRequest
        {
            public int ID { get; set; }
        }
    }
}
