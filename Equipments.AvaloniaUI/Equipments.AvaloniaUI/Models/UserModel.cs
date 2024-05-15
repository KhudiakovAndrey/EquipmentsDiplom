using Avalonia.Media.Imaging;
using Equipments.AvaloniaUI.Resources;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Models
{
    public class UserModel
    {
        public Guid ID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public FullEmployeModel Employe { get; set; }
    }
    public class FullEmployeModel
    {
        public Guid ID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Post { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string NumberAssignedOffice { get; set; } = string.Empty;
        public string DescriptionAssignedOffice { get; set; } = string.Empty;
        [JsonIgnore]
        public Task<Bitmap?> ImageUrl => ImageHelper.LoadFromWeb(new Uri("https://localhost:44304/api/Employees/me/image"));

    }
}
