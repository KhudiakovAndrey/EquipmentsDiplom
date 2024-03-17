using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class ActsAddResource
    {
        public int IdActAddResources { get; set; }
        public string NumberAct { get; set; }
        public string NumberRes { get; set; }
        public float CountRes { get; set; }
        public decimal CostRes { get; set; }

        public virtual Act NumberActNavigation { get; set; }
        public virtual EquipmentResource NumberResNavigation { get; set; }
    }
}
