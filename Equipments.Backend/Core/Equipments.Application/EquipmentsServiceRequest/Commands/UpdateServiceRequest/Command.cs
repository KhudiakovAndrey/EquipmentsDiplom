﻿using MediatR;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Commands
{
    public partial class UpdateServiceRequest
    {
        public class Command : IRequest
        {
            public Guid ID { get; set; }
            public Guid IDResponsible { get; set; }
            public Guid IDSystemAdministration { get; set; }
            public string EquipmentType { get; set; } = string.Empty;
            public string ProblemType { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string BrokenEquipmentDescription { get; set; } = string.Empty;
        }
    }
}