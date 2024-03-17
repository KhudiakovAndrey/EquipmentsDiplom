using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class EquipmentResource
    {
        public EquipmentResource()
        {
            ActsAddResources = new HashSet<ActsAddResource>();
            ActsDeleteResources = new HashSet<ActsDeleteResource>();
        }

        public string Title { get; set; }
        public string Fulltitle { get; set; }
        public string NumberRes { get; set; }
        public float CountRes { get; set; }
        public decimal CostRes { get; set; }
        public int IdEquipmentsCustodians { get; set; }

        public virtual EquipmentCustodian IdEquipmentsCustodiansNavigation { get; set; }
        public virtual ICollection<ActsAddResource> ActsAddResources { get; set; }
        public virtual ICollection<ActsDeleteResource> ActsDeleteResources { get; set; }
    }
}
