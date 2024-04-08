using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class AssignedOffice
    {
        public AssignedOffice()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
