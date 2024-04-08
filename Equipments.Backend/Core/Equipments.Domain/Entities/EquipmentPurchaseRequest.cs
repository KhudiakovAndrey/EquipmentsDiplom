using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class EquipmentPurchaseRequest
    {
        public EquipmentPurchaseRequest()
        {
            CommercialOffers = new HashSet<CommercialOffer>();
            PurchasedEquipments = new HashSet<PurchasedEquipment>();
        }

        public Guid Id { get; set; }
        public Guid IdsystemAdministrator { get; set; }
        public string PurchaseReason { get; set; }
        public DateTime CreationDate { get; set; }
        public string PurchaseDeadline { get; set; }

        public virtual Employee IdsystemAdministratorNavigation { get; set; }
        public virtual ICollection<CommercialOffer> CommercialOffers { get; set; }
        public virtual ICollection<PurchasedEquipment> PurchasedEquipments { get; set; }
    }
}
