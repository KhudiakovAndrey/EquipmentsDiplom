using System;

namespace Equipments.AvaloniaUI.Models
{
    public class RequestStatusChangeModel
    {
        public int ID { get; set; }
        public DateTime ChangeStatusDate { get; set; }
        public RequestStatusModel Status { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
