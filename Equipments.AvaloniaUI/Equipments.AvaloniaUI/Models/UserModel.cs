using Avalonia.Media.Imaging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Models
{
    public class UserModel : ReactiveObject
    {
        public Guid ID { get; set; }
        [Reactive]
        [DataMember]
        public string UserName { get; set; } = string.Empty;
        [Reactive]
        [DataMember]
        public string Email { get; set; } = string.Empty;
        [Reactive]
        [DataMember]
        public string PhoneNumber { get; set; } = string.Empty;
        [Reactive]
        [DataMember]
        public string Role { get; set; } = string.Empty;
        public FullEmployeModel Employe { get; set; }

    }
    public class FullEmployeModel : ReactiveObject
    {
        [DataMember]
        public Guid ID { get; set; }
        [Reactive]
        [DataMember]
        public string FullName { get; set; } = string.Empty;
        [Reactive]
        [DataMember]
        public string Post { get; set; } = string.Empty;
        [Reactive]
        [DataMember]
        public string Department { get; set; } = string.Empty;
        [Reactive]
        [DataMember]
        public string NumberAssignedOffice { get; set; } = string.Empty;
        [Reactive]
        [DataMember]
        public string DescriptionAssignedOffice { get; set; } = string.Empty;
        [JsonIgnore]
        public Task<Bitmap?> ImageUrl => ImageHelper.LoadFromWeb(new Uri("http://equipments.kpk/api/Employees/me/image"));

    }
}
