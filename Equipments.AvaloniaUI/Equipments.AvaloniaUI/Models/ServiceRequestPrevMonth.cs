using System.ComponentModel;

namespace Equipments.AvaloniaUI.Models
{
    public class ServiceRequestPrevMonth
    {
        [DisplayName("Тип оборудования")]
        public string EquipmentType { get; set; }
        [DisplayName("Количество поданных заявок за месяц")]
        public int RequestCount { get; set; }
    }
}
