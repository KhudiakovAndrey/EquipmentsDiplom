using System;

namespace Equipments.AvaloniaUI.Models
{
    public class UpdateEquipmentServiceRequestModel
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
