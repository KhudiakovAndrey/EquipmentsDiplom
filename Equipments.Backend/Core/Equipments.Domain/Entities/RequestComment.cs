using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class RequestComment
    {
        public int Id { get; set; }
        public Guid IdequipmentServiceRequest { get; set; }
        public Guid Idemployee { get; set; }
        public string Comment { get; set; }

        public virtual Employee IdemployeeNavigation { get; set; }
        public virtual EquipmentServiceRequest IdequipmentServiceRequestNavigation { get; set; }
    }
}
