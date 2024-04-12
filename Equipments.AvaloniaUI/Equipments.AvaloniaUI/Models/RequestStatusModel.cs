using System;

namespace Equipments.AvaloniaUI.Models
{
    public class RequestStatusModel
    {
        public int ID { get; set; }
        public DateTime ChangeStatusDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
