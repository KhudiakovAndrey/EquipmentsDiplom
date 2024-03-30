using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using Microsoft.Extensions.DependencyInjection;
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
    public class AuthorizationViewModel : ViewModelBase
    {
        private readonly SettingsDbContext _dbContext;
        private readonly LoginService _loginService;

        [Reactive]
        public LoginViewModel Login { get; set; } = new LoginViewModel();

        public AuthorizationViewModel(SettingsDbContext dbContext, LoginService loginService)
        {
            var canExecuteAuthCommand = this.WhenAnyValue(
                vm => vm.Login.Username,
                vm => vm.Login.Password,
                (name, pass) => !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(pass));

            AuthCommand = ReactiveCommand.CreateFromTask(Auth, canExecuteAuthCommand);

            _dbContext = dbContext;
            _loginService = loginService;
        }
        public ReactiveCommand<Unit, Unit> AuthCommand { get; private set; }
        public async Task Auth()
        {
            ErrorMessage = string.Empty;
            ShowError = false;
            var response = await _loginService.LoginAsync(Login);
            if (response.IsSucces)
            {
                //Авторизация прошла успешно
            }
            else
            {
                //Ошибка авторизации. 
                ErrorMessage = "Ошибка авторизации. ";

                if (response.Message.ErrorCode == Api.ErrorCodes.email_not_confirmed)
                {
                    //Электронная почта не подтверждена.
                    ErrorMessage += response.Message.ErrorMessage;

                }
                else
                {
                    ErrorMessage += response.Message.ErrorMessage;
                }

                ShowError = true;
            }
        }
        [Reactive]
        public bool ShowError { get; set; }
        [Reactive]
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
