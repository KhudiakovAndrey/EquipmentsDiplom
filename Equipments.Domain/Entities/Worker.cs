using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class Worker
    {
        public Worker()
        {
            EquipmentCustodians = new HashSet<EquipmentCustodian>();
            TechnicalSupports = new HashSet<TechnicalSupport>();
            Users = new HashSet<User>();
        }

        public int Idworker { get; set; }
        public string Fio { get; set; }
        public int Iddepartment { get; set; }
        public int Idpost { get; set; }
        public bool Isadmin { get; set; }
        public string Image { get; set; }

        public virtual Department IddepartmentNavigation { get; set; }
        public virtual Post IdpostNavigation { get; set; }
        public virtual ICollection<EquipmentCustodian> EquipmentCustodians { get; set; }
        public virtual ICollection<TechnicalSupport> TechnicalSupports { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
