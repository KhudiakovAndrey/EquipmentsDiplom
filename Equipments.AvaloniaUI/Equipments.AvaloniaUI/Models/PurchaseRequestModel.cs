using System;

namespace Equipments.AvaloniaUI.Models
{
    public class PurchaseRequestModel
    {
        public Guid ID { get; set; }
        public Guid IDSystemAdministration { get; set; }
        public string PurchaseReason { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public string PurchaseDeadline { get; set; } = string.Empty;
    }
}
