using MediatR;
using System;

namespace Equipments.Application.RequestStatusChanges.Commands
{
    public partial class UpdateRequestStatus
    {
        public class Command : IRequest
        {
            public int ID { get; set; }
            public Guid IDRequestService { get; set; }
            public int IDStatus { get; set; }
            public string? Description { get; set; }
        }
    }
}
