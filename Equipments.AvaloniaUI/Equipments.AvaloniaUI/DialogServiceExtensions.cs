using Equipments.AvaloniaUI.ViewModels;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI
{
    public static class DialogServiceExtensions
    {
        public static async Task<bool> AskQuestionAsync(this IDialogService service, INotifyPropertyChanged ownerViewModel,
            string message, string? title = null)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));

            var vm = service.CreateViewModel<AskQuestionViewModel>();
            vm.Title = title ?? "Заголовок";
            vm.Message = message;
            var settings = new DialogHostSettings(vm);
            await service.ShowDialogHostAsync(ownerViewModel, settings).ConfigureAwait(true);
            return vm.DialogResult ?? false;
        }
    }
}
