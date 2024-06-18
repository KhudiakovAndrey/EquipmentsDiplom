using System.ComponentModel;

namespace Equipments.AvaloniaUI.Models
{
    public class ReportEmployeByDepartmentModel
    {
        [DisplayName("ФИО")]
        public string FullName { get; set; }
        [DisplayName("Должность")]
        public string PostName { get; set; }
        [DisplayName("Кабинет")]
        public string OfficeNumber { get; set; }

    }
}
