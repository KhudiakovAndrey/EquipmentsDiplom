using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class EquipmentCustodian
    {
        public EquipmentCustodian()
        {
            Acts = new HashSet<Act>();
            EquipmentResources = new HashSet<EquipmentResource>();
            InventoryObjects = new HashSet<InventoryObject>();
            ServiceRequests = new HashSet<ServiceRequest>();
        }

        public int IdequipmentCustodians { get; set; }
        public string NumberOffice { get; set; }
        public int? Idworker { get; set; }

        public virtual Worker IdworkerNavigation { get; set; }
        public virtual OfficeAssigment NumberOfficeNavigation { get; set; }
        public virtual ICollection<Act> Acts { get; set; }
        public virtual ICollection<EquipmentResource> EquipmentResources { get; set; }
        public virtual ICollection<InventoryObject> InventoryObjects { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
