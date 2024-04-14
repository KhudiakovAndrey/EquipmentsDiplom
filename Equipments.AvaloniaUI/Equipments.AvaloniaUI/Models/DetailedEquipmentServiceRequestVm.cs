using System.Collections.Generic;
using System;

namespace Equipments.AvaloniaUI.Models
{
    public class DetailedEquipmentServiceRequestVm
    {
        public Guid ID { get; set; }
        public EmployeModel Responsible { get; set; } = new();
        public EmployeModel SystemAdministrator { get; set; } = new();
        public ProblemTypeDto ProblemType { get; set; } = new();
        public string DetailedDescription { get; set; } = string.Empty;
        public string BrokenEquipmentDescription { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public List<RequestStatusChangeModel> Statues { get; set; } = new();
    }
}
