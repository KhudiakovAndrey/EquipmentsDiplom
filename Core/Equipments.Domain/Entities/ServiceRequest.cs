using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class ServiceRequest
    {
        public ServiceRequest()
        {
            ProgressServiceRequests = new HashSet<ProgressServiceRequest>();
        }

        public int IdServiceRequests { get; set; }
        public string Title { get; set; }
        public int IdEquipmentCustodians { get; set; }
        public int IdTechnicalSupport { get; set; }
        public int IdEquipment { get; set; }
        public DateTime DatetimeAdd { get; set; }
        public string Description { get; set; }

        public virtual EquipmentCustodian IdEquipmentCustodiansNavigation { get; set; }
        public virtual Equipment IdEquipmentNavigation { get; set; }
        public virtual TechnicalSupport IdTechnicalSupportNavigation { get; set; }
        public virtual ICollection<ProgressServiceRequest> ProgressServiceRequests { get; set; }
    }
}
