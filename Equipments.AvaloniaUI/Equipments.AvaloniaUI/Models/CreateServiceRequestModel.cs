using System;

namespace Equipments.AvaloniaUI.Models
{
    public class CreateServiceRequestModel
    {
        public Guid IDResponsible { get; set; }
        public Guid IDSystemAdministrator { get; set; }
        public string EquipmentType { get; set; } = string.Empty;
        public string ProblemType { get; set; } = string.Empty;
        public string? DetailedDescription { get; set; } = string.Empty;
        public string BrokenEquipmentDescription { get; set; } = string.Empty;
    }
}
