using Avalonia.Platform.Storage;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using Equipments.AvaloniaUI.Services.API;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using HanumanInstitute.MvvmDialogs.FileSystem;
using ReactiveUI.Fody.Helpers;
using SQLitePCL;
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
        private readonly EmployeesService _employeesService;
        private readonly UserService _userService;
        public MainMenuWindowViewModel(IDialogService dialogService,
            EmployeesService employeesService,
            UserService userService)
        {
            _dialogService = dialogService;
            _employeesService = employeesService;
            _userService = userService;
            Initialize();
        }

        private async void Initialize()
        {
            if (JwtTokenData.AccessToken != null)
                User = await GetMyUser();
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

        public async Task<bool?> ShowAskQuestionDialogAsync(string message, string? title = null)
        {
            bool? result = await _dialogService.AskQuestionAsync(this, message, title);
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


        private async Task<UserModel> GetMyUser()
        {
            var resultMyUser = await _userService.GetMeUser();
            if (resultMyUser.IsSucces)
            {
                var resultMyEmploye = await _employeesService.GetMeEmploye();
                if (resultMyEmploye.IsSucces)
                {
                    resultMyUser.Data.Employe = resultMyEmploye.Data;
                    return resultMyUser.Data;
                }
            }
            return null;
        }

        [Reactive] public UserModel User { get; set; }

    }
}
