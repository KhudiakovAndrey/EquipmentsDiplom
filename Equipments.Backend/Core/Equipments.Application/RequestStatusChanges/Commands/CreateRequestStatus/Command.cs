using MediatR;
using System;

namespace Equipments.Application.RequestStatusChanges.Commands
{
    public partial class CreateRequestStatus
    {
        public class Command : IRequest<int>
        {
            public Guid IDRequestService { get; set; }
            public int IDStatus { get; set; }
            public string? Description { get; set; }
        }
    }
}
