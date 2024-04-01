using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using Equipments.AvaloniaUI.Views;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly RegistrationService _registrationService;
        private readonly IDialogService _dialogService;

        public RegistrationViewModel(RegistrationService registrationService, IDialogService dialogService)
        {
            RegistrationCommand = ReactiveCommand.CreateFromTask(Registration);

            _registrationService = registrationService;
            _dialogService = dialogService;
        }

        public ReactiveCommand<Unit, Unit> RegistrationCommand { get; private set; }
        private async Task Registration()
        {
            var response = await _registrationService.RegistrationUserAsync(Register);
            if (response.IsSucces)
            {

            }
            else
            {
                //Неудачно
                await _dialogService.ShowDialogHostAsync(
                    this,
                    new DialogHostSettings(response.Message.ErrorMessage)
                    {
                        CloseOnClickAway = true
                    }).ConfigureAwait(true);
            }
        }
        [Reactive] public string Username { get; set; } = string.Empty;

        [Reactive] public string Email { get; set; } = string.Empty;

        [Reactive] public string Password { get; set; } = string.Empty;

        [Reactive] public string ConfirmPassword { get; set; } = string.Empty;

    }

}
