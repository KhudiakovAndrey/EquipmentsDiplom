using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Equipments.AvaloniaUI.Models
{
    public class LoginViewModel : ReactiveObject
    {
        [Reactive]
        public string Username { get; set; } = string.Empty;
        [Reactive]
        public string Password { get; set; } = string.Empty;
    }
}
