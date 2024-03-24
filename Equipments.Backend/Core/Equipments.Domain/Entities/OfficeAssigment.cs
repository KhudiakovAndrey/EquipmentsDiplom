using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class OfficeAssigment
    {
        public OfficeAssigment()
        {
            EquipmentCustodians = new HashSet<EquipmentCustodian>();
        }

        public string NumberOffice { get; set; }
        public string Title { get; set; }

        public virtual ICollection<EquipmentCustodian> EquipmentCustodians { get; set; }
    }
}
