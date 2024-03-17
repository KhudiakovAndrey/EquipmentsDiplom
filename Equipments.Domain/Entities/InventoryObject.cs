using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class InventoryObject
    {
        public int IdAdditionallyEquipment { get; set; }
        public int IdEquipment { get; set; }
        public string InventoryNumber { get; set; }
        public int IdEquipmentCustodians { get; set; }
        public decimal CostEq { get; set; }
        public DateTime? DateAdd { get; set; }
        public DateTime? DateUse { get; set; }
        public DateTime? DateDelete { get; set; }

        public virtual EquipmentCustodian IdEquipmentCustodiansNavigation { get; set; }
        public virtual Equipment IdEquipmentNavigation { get; set; }
    }
}
