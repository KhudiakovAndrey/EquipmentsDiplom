using Avalonia.Media.Imaging;
using Equipments.AvaloniaUI.Resources;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Models
{
    public class UserModel : ReactiveObject,
IEquatable<UserModel?>
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

        public override bool Equals(object? obj)
        {
            return Equals(obj as UserModel);
        }

        public bool Equals(UserModel? other)
        {
            return other is not null ||
                   ID.Equals(other.ID) ||
                   UserName == other.UserName ||
                   Email == other.Email ||
                   PhoneNumber == other.PhoneNumber ||
                   Role == other.Role;
        }

        public static bool operator ==(UserModel? left, UserModel? right)
        {
            return EqualityComparer<UserModel>.Default.Equals(left, right);
        }

        public static bool operator !=(UserModel? left, UserModel? right)
        {
            return !(left == right);
        }
    }
    public class FullEmployeModel : ReactiveObject, IEquatable<FullEmployeModel?>
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
        public Task<Bitmap?> ImageUrl => ImageHelper.LoadFromWeb(new Uri("https://localhost:44304/api/Employees/me/image"));

        public override bool Equals(object? obj)
        {
            return Equals(obj as FullEmployeModel);
        }

        public bool Equals(FullEmployeModel? other)
        {
            return other is not null &&
                   ID.Equals(other.ID) &&
                   FullName == other.FullName &&
                   Post == other.Post &&
                   Department == other.Department &&
                   NumberAssignedOffice == other.NumberAssignedOffice &&
                   DescriptionAssignedOffice == other.DescriptionAssignedOffice &&
                   EqualityComparer<Task<Bitmap?>>.Default.Equals(ImageUrl, other.ImageUrl);
        }

        public static bool operator ==(FullEmployeModel? left, FullEmployeModel? right)
        {
            return EqualityComparer<FullEmployeModel>.Default.Equals(left, right);
        }

        public static bool operator !=(FullEmployeModel? left, FullEmployeModel? right)
        {
            return !(left == right);
        }
    }
}
