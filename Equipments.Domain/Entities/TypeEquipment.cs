using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class TypeEquipment
    {
        public TypeEquipment()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int IdTypeEquipment { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
