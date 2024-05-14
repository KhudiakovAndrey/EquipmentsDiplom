using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Equipments.AvaloniaUI.Models
{
    public class PaginationEquipmentsServiceRequestVM : ReactiveObject
    {
        [DataMember]
        [Reactive] public List<EquipmentsServiceRequestVM> Items { get; set; } = new();
        [DataMember]
        [Reactive] public int PageNumber { get; set; } = 1;
        [DataMember]
        [Reactive] public int PageSize { get; set; }
        [DataMember]
        [Reactive] public int TotalCount { get; set; }
        [DataMember]
        [Reactive] public int TotalPages { get; set; }
        [DataMember]
        [Reactive] public int CountFound { get; set; }

    }

    [DataContract]
    public class EquipmentsServiceRequestVM : ReactiveObject, ISelectableModel
    {
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public EmployeModel Responsible { get; set; }
        [DataMember]
        public EmployeModel SystemAdministration { get; set; }
        [DataMember]
        public string ProblemType { get; set; } = string.Empty;
        [DataMember]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        [Reactive] public bool IsSelected { get; set; } = false;
    }
}
