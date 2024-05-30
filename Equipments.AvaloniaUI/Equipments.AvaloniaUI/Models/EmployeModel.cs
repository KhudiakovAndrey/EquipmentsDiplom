using Avalonia.Media.Imaging;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Models
{
    public class EmployeModel
    {
        public Guid ID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Post { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public int RoleID { get; set; }

        [JsonIgnore]
        public Task<Bitmap?> ImageUrl => ImageHelper.LoadFromWeb(new Uri($"https://equipments.kpk/api/employees/{ID}/image"));
    }
}
