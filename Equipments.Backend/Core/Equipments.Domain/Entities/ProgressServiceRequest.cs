using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class ProgressServiceRequest
    {
        public int IdProgressServiceRequest { get; set; }
        public int IdServiceRequest { get; set; }
        public int IdStatusRequest { get; set; }
        public string Description { get; set; }

        public virtual ServiceRequest IdServiceRequestNavigation { get; set; }
        public virtual StatusRequest IdStatusRequestNavigation { get; set; }
    }
}
