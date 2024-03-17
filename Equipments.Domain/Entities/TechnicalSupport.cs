using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class TechnicalSupport
    {
        public TechnicalSupport()
        {
            ServiceRequests = new HashSet<ServiceRequest>();
        }

        public int Idtechnicalsupport { get; set; }
        public int? Idworker { get; set; }

        public virtual Worker IdworkerNavigation { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
