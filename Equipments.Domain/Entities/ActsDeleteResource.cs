using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class ActsDeleteResource
    {
        public int IdActDeleteResources { get; set; }
        public string NumberAct { get; set; }
        public string NumberRes { get; set; }
        public float CountRes { get; set; }
        public decimal CostRes { get; set; }
        public string ReasonDelete { get; set; }

        public virtual Act NumberActNavigation { get; set; }
        public virtual EquipmentResource NumberResNavigation { get; set; }
    }
}
