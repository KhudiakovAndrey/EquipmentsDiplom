using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Models
{
    public class ConfirmEmailModel : ReactiveObject
    {
        public ConfirmEmailModel()
        {
            IsExecuteCommand = this.WhenAnyValue(model => model.Code,
                code => !string.IsNullOrWhiteSpace(code) && code.Length == 6);
        }

        [Required(ErrorMessage = "Код обязательно должен быть введён")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Длина кода 6 символом")]
        [Reactive] public string Code { get; set; } = string.Empty;
        public IObservable<bool> IsExecuteCommand { get; }

    }
}
