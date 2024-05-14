using Avalonia.Platform.Storage;
using Equipments.AvaloniaUI.Models;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using HanumanInstitute.MvvmDialogs.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class MainMenuWindowViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        public MainMenuWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
        public async Task ShowDialogHostAsync(string message)
        {
            await _dialogService.ShowDialogHostAsync(
                    this,
                    new DialogHostSettings(message)
                    {
                        CloseOnClickAway = true
                    }).ConfigureAwait(true);
        }

        public async Task<bool> ShowAskQuestionDialogAsync(string message, string? title = null)
        {
            bool result = await _dialogService.AskQuestionAsync(this, message, title);
            return result;
        }
        public async Task<bool?> ShowDialogEditRequestStatusChange(UpdateRequestStatusChangeModel? model)
        {
            var result = await _dialogService.ShowEditRequestStatusChange(this, model);
            return result;
        }
        public async Task<IDialogStorageFile?> ShowSaveFileDialog()
        {
            var result = await _dialogService.ShowSaveFileDialogAsync(this);
            return result;
        }
        public async Task<IEnumerable<IStorageItem>?> ShowUploadFileDialog()
        {
            var files = await _dialogService.ShowUploadFileDialog(this);
            return files;
        }

    }
}
