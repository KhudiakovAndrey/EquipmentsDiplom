using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Equipments.AvaloniaUI.Models
{
    public class LoginViewModel : ReactiveObject
    {
        [Reactive]
        [DataMember]
        public string Username { get; set; } = string.Empty;

        [Reactive]
        [DataMember]
        public string Password { get; set; } = string.Empty;
        public LoginViewModel()
        {
            IsValid = this.WhenAnyValue(
                x => x.Username,
                x => x.Password,
                (username, password) => !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password));
        }

        [JsonIgnore]
        public IObservable<bool> IsValid { get; }
    }
}
