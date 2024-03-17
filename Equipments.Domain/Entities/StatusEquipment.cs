using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class StatusEquipment
    {
        public StatusEquipment()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int IdStatusEquipment { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
