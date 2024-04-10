using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            EquipmentPurchaseRequests = new HashSet<EquipmentPurchaseRequest>();
            EquipmentServiceRequestIdresponsibleNavigations = new HashSet<EquipmentServiceRequest>();
            EquipmentServiceRequestIdsystemAdministratorNavigations = new HashSet<EquipmentServiceRequest>();
            RequestComments = new HashSet<RequestComment>();
        }

        public Guid Id { get; set; }
        public Guid? Iduser { get; set; }
        public string FullName { get; set; }
        public int Idpost { get; set; }
        public int Iddepartment { get; set; }
        public int? IDEmployeeRole { get; set; }
        public int? IdassignedOffice { get; set; }
        public string Photo { get; set; }

        public virtual EmployeeRole EmployeeRole { get; set; }
        public virtual AssignedOffice IdassignedOfficeNavigation { get; set; }
        public virtual Department IddepartmentNavigation { get; set; }
        public virtual Post IdpostNavigation { get; set; }
        public virtual ICollection<EquipmentPurchaseRequest> EquipmentPurchaseRequests { get; set; }
        public virtual ICollection<EquipmentServiceRequest> EquipmentServiceRequestIdresponsibleNavigations { get; set; }
        public virtual ICollection<EquipmentServiceRequest> EquipmentServiceRequestIdsystemAdministratorNavigations { get; set; }
        public virtual ICollection<RequestComment> RequestComments { get; set; }
    }
}
