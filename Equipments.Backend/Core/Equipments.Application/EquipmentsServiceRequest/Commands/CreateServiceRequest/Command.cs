using MediatR;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Commands
{
    public partial class CreateServiceRequest
    {
        public class Command : IRequest<Guid>
        {
            public Guid IDResponsible { get; set; }
            public Guid IDSystemAdministrator { get; set; }
            public string EquipmentType { get; set; } = string.Empty;
            public string ProblemType { get; set; } = string.Empty;
            public string? DetailedDescription { get; set; } = string.Empty;
            public string BrokenEquipmentDescription { get; set; } = string.Empty;
        }
    }
}
