using Equipments.AvaloniaUI.Services.API;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class ConfirmEmailViewModel : ViewModelBase
    {
        private readonly LoginService _loginService;
        private readonly IDialogService _dialogService;

        public ConfirmEmailViewModel(LoginService loginService, IDialogService dialogService)
        {
            _loginService = loginService;
            _dialogService = dialogService;

            var isExecuteEmailConfirmedCommand = this.WhenAnyValue(
                vm => vm.ConfirmCode,
                code => !string.IsNullOrWhiteSpace(code) && code.Count() == 6);

            EmailConfirmedCommand = ReactiveCommand.CreateFromTask(EmailConfirmed, isExecuteEmailConfirmedCommand);
        }

        public ReactiveCommand<Unit, Unit> EmailConfirmedCommand { get; private set; }
        private async Task EmailConfirmed()
        {
            var response = await _loginService.SendEmailCode(ConfirmCode);
            if (response.IsSucces)
            {
                //Успешно
            }
        }

        public async void SendEmailCode()
        {
            var repsonse = await _loginService.SendEmailCode(Email);
            if (!repsonse.IsSucces)
            {
                await _dialogService.ShowDialogHostAsync(
                    this,
                    new DialogHostSettings($"Не удалось отправить код подтверждения на электронную почту {Email}. Пожалуйста повторите попытку позже.")
                    {
                        CloseOnClickAway = true,
                    }).ConfigureAwait(true);
            }
        }

        [Reactive]
        [DataMember]
        public string Email { get; set; } = string.Empty;

        [Reactive]
        [Required(ErrorMessage = "Код обязательно должен быть введён")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Код не должен превышать 6 символом")]
        public string ConfirmCode { get; set; } = string.Empty;

    }
}
