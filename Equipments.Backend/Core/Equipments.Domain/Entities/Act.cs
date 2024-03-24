using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class Act
    {
        public Act()
        {
            ActsAcceptEquipments = new HashSet<ActsAcceptEquipment>();
            ActsAddResources = new HashSet<ActsAddResource>();
            ActsDeleteEquipments = new HashSet<ActsDeleteEquipment>();
            ActsDeleteResources = new HashSet<ActsDeleteResource>();
        }

        public string NumberAct { get; set; }
        public DateTime DatetimeAdd { get; set; }
        public int IdEquipmentsCustodians { get; set; }
        public bool? IsDelete { get; set; }

        public virtual EquipmentCustodian IdEquipmentsCustodiansNavigation { get; set; }
        public virtual ICollection<ActsAcceptEquipment> ActsAcceptEquipments { get; set; }
        public virtual ICollection<ActsAddResource> ActsAddResources { get; set; }
        public virtual ICollection<ActsDeleteEquipment> ActsDeleteEquipments { get; set; }
        public virtual ICollection<ActsDeleteResource> ActsDeleteResources { get; set; }
    }
}
