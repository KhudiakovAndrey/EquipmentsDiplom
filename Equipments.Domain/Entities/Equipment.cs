using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class Equipment
    {
        public Equipment()
        {
            ActsAcceptEquipments = new HashSet<ActsAcceptEquipment>();
            ActsDeleteEquipments = new HashSet<ActsDeleteEquipment>();
            InventoryObjects = new HashSet<InventoryObject>();
            ServiceRequests = new HashSet<ServiceRequest>();
        }

        public int IdEquipment { get; set; }
        public string Title { get; set; }
        public string Fulltitle { get; set; }
        public bool Isgroup { get; set; }
        public int IdStatusEquipment { get; set; }
        public int IdTypeEquipment { get; set; }

        public virtual StatusEquipment IdStatusEquipmentNavigation { get; set; }
        public virtual TypeEquipment IdTypeEquipmentNavigation { get; set; }
        public virtual ICollection<ActsAcceptEquipment> ActsAcceptEquipments { get; set; }
        public virtual ICollection<ActsDeleteEquipment> ActsDeleteEquipments { get; set; }
        public virtual ICollection<InventoryObject> InventoryObjects { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
