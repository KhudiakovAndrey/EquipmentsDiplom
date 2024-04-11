using HanumanInstitute.MvvmDialogs;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class AskQuestionViewModel : ViewModelBase, IModalDialogViewModel, ICloseable
    {
        public event EventHandler? RequestClose;
        public bool? DialogResult { get; set; }
        [Reactive] public string Title { get; set; } = "Заголовок";
        [Reactive] public string Message { get; set; } = string.Empty;

        private ReactiveCommand<Unit, Unit>? _ok;
        public ReactiveCommand<Unit, Unit> Ok => _ok ??= ReactiveCommand.Create(OkImpl);
        private void OkImpl()
        {
            DialogResult = true;
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private ReactiveCommand<Unit, Unit>? _cancel;
        public ReactiveCommand<Unit, Unit> Cancel => _cancel ??= ReactiveCommand.Create(CancelImpl);
        private void CancelImpl()
        {
            DialogResult = false;
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
