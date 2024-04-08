using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class ProblemType
    {
        public ProblemType()
        {
            EquipmentServiceRequests = new HashSet<EquipmentServiceRequest>();
        }

        public int Id { get; set; }
        public int IdequipmentType { get; set; }
        public string Description { get; set; }

        public virtual EquipmentType IdequipmentTypeNavigation { get; set; }
        public virtual ICollection<EquipmentServiceRequest> EquipmentServiceRequests { get; set; }
    }
}
