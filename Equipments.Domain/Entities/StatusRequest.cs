using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class StatusRequest
    {
        public StatusRequest()
        {
            ProgressServiceRequests = new HashSet<ProgressServiceRequest>();
        }

        public int IdStatusRequest { get; set; }
        public string Title { get; set; }

        public virtual ICollection<ProgressServiceRequest> ProgressServiceRequests { get; set; }
    }
}
