using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class RequestStatus
    {
        public RequestStatus()
        {
            RequestStatusChanges = new HashSet<RequestStatusChange>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RequestStatusChange> RequestStatusChanges { get; set; }
    }
}
