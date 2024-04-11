using MediatR;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Commands
{
    public partial class DeleteServiceRequest
    {
        public class Command : IRequest
        {
            public Guid ID { get; set; }
        }
    }
}
