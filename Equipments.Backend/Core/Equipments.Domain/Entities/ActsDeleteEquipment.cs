using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class ActsDeleteEquipment
    {
        public int IdActDeleteEquipments { get; set; }
        public string NumberAct { get; set; }
        public int IdEquipment { get; set; }
        public float CountRes { get; set; }
        public decimal CostRes { get; set; }
        public string ReasonDelete { get; set; }

        public virtual Equipment IdEquipmentNavigation { get; set; }
        public virtual Act NumberActNavigation { get; set; }
    }
}
