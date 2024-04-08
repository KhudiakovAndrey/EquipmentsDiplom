using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reactive;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class ConfirmEmailViewModel : ViewModelBase
    {
        private readonly UserService _loginService;

        public ConfirmEmailViewModel(UserService loginService)
        {
            _loginService = loginService;

            ConfirmEmail = new ConfirmEmailModel();

            IObservable<bool> isExecuteEmailConfirmedCommand = this.WhenAnyValue(vm => vm.ConfirmEmail.Code,
                code => !string.IsNullOrWhiteSpace(code) && code.Length == 6);

            EmailConfirmedCommand = ReactiveCommand.CreateFromTask(EmailConfirmed, isExecuteEmailConfirmedCommand);
        }

        public ReactiveCommand<Unit, Unit> EmailConfirmedCommand { get; private set; }
        private async Task EmailConfirmed()
        {
            try
            {
                var response = await _loginService.ConfirmEmail(ConfirmEmail);
                if (response.IsSucces)
                {
                    //Успешно
                }
                else
                {
                    OnErrorHandler(response.Message.ErrorMessage);
                }
            }
            catch (WebException ex)
            {
                Log.Fatal(ex, "Не удалось отправить запрос на подтверждение кода");
                throw;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Непредвиденная ошибка при отправке запроса на подтверждение кода");
            }
        }

        public async void SendEmailCode()
        {
            try
            {
                var response = await _loginService.SendEmailCode(Email);
                if (!response.IsSucces)
                {
                    OnErrorHandler(response.Message.ErrorMessage);
                }
            }
            catch (WebException ex)
            {
                Log.Fatal(ex, "Не удалось отправить запрос на отпраку кода подтверждения");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Непредвиденная ошибка при отправке запроса на подтверждение кода");
            }
        }

        public string Email { get; set; } = string.Empty;

        public ConfirmEmailModel ConfirmEmail { get; set; }
    }
}
