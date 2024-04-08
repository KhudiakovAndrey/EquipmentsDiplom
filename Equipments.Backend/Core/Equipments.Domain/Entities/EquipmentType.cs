using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class EquipmentType
    {
        public EquipmentType()
        {
            ProblemTypes = new HashSet<ProblemType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProblemType> ProblemTypes { get; set; }
    }
}
