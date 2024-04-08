using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class CommercialOffer
    {
        public int Id { get; set; }
        public Guid IdequipmentPurchaseRequest { get; set; }
        public decimal Price { get; set; }
        public int IdcommercialOrganization { get; set; }
        public string InformationSource { get; set; }

        public virtual CommercialOrganization IdcommercialOrganizationNavigation { get; set; }
        public virtual EquipmentPurchaseRequest IdequipmentPurchaseRequestNavigation { get; set; }
    }
}
