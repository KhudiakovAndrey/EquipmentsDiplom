using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class Department
    {
        public Department()
        {
            Workers = new HashSet<Worker>();
        }

        public int Iddepartment { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
