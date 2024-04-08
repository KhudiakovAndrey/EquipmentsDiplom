using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class PurchasedEquipment
    {
        public int Id { get; set; }
        public Guid IdequipmentPurchaseRequest { get; set; }
        public string EquipmentName { get; set; }
        public string MeasurementUnit { get; set; }
        public int Quantity { get; set; }
        public string AdditionalCondition { get; set; }

        public virtual EquipmentPurchaseRequest IdequipmentPurchaseRequestNavigation { get; set; }
    }
}
