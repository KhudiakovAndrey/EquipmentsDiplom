using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Equipments.AvaloniaUI.Models
{
    public class ConfirmEmailModel : ReactiveObject
    {
        [DataMember]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Длина кода 6 символом")]
        [Reactive] public string Code { get; set; } = string.Empty;
    }
}
