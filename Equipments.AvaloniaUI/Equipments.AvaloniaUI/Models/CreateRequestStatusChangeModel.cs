using System;

namespace Equipments.AvaloniaUI.Models
{
    public class CreateRequestStatusChangeModel
    {
        public Guid IDRequestService { get; set; }
        public int IDStatus { get; set; }
        public string? Description { get; set; }
    }
}
