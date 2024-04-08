using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class CommercialOrganization
    {
        public CommercialOrganization()
        {
            CommercialOffers = new HashSet<CommercialOffer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public virtual ICollection<CommercialOffer> CommercialOffers { get; set; }
    }
}
