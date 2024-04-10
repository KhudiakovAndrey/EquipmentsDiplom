using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Equipments.AvaloniaUI.Models
{
    public class PaginationEquipmentsServiceRequestVM
    {
        [DataMember]
        [Reactive] public List<EquipmentsServiceRequestVM> Items { get; set; } = new();
        [DataMember]
        [Reactive] public int PageNumber { get; set; } = 1;
        [DataMember]
        [Reactive] public int PageSize { get; set; } = 3;
        [DataMember]
        [Reactive] public int TotalCount { get; set; }
        [DataMember]
        [Reactive] public int TotalPages { get; set; }

    }

    public class EquipmentsServiceRequestVM
    {
        public Guid ID { get; set; }
        public string Responsible { get; set; } = string.Empty;
        public string SystemAdministration { get; set; } = string.Empty;
        public string ProblemType { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }

    }
}
