using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;

namespace Equipments.AvaloniaUI.Models
{
    public class PaginationEquipmentsServiceRequestVM
    {
        public List<EquipmentsServiceRequestVM> Items { get; set; } = new();
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

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
