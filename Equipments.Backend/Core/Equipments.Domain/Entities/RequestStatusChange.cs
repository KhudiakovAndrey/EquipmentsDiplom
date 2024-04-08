using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class RequestStatusChange
    {
        public int Id { get; set; }
        public Guid IdequipmentServiceRequest { get; set; }
        public DateTime StatusChangeDate { get; set; }
        public int Status { get; set; }
        public string WorkDescription { get; set; }

        public virtual EquipmentServiceRequest IdequipmentServiceRequestNavigation { get; set; }
        public virtual RequestStatus StatusNavigation { get; set; }
    }
}
