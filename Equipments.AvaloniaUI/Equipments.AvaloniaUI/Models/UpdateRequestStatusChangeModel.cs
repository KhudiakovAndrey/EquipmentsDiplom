using System;

namespace Equipments.AvaloniaUI.Models
{
    public class UpdateRequestStatusChangeModel
    {
        public int ID { get; set; }
        public Guid IDRequestService { get; set; }
        public int IDStatus { get; set; }
        public string? Description { get; set; }
    }
}
