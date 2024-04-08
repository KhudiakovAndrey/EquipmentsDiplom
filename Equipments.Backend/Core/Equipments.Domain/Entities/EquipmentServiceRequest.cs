using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class EquipmentServiceRequest
    {
        public EquipmentServiceRequest()
        {
            RequestComments = new HashSet<RequestComment>();
            RequestStatusChanges = new HashSet<RequestStatusChange>();
        }

        public Guid Id { get; set; }
        public Guid Idresponsible { get; set; }
        public Guid IdsystemAdministrator { get; set; }
        public int IdproblemType { get; set; }
        public string DetailedDescription { get; set; }
        public string BrokenEquipmentDescription { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ProblemType IdproblemTypeNavigation { get; set; }
        public virtual Employee IdresponsibleNavigation { get; set; }
        public virtual Employee IdsystemAdministratorNavigation { get; set; }
        public virtual ICollection<RequestComment> RequestComments { get; set; }
        public virtual ICollection<RequestStatusChange> RequestStatusChanges { get; set; }
    }
}
