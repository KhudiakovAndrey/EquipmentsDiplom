using Avalonia.Controls.Primitives;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using Microsoft.EntityFrameworkCore;
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
            AuthCommand = ReactiveCommand.CreateFromTask(Auth, Login.IsValid);

            _dbContext = dbContext;
            _loginService = loginService;
        }
        public ReactiveCommand<Unit, Unit> AuthCommand { get; private set; }
        public async Task Auth()
        {
            ErrorMessage = string.Empty;
            ErrorEmailNotConfirmMessage = string.Empty;

            var response = await _loginService.LoginAsync(Login);
            if (response.IsSucces)
            {
                string token = response.Data.Token;

                //Сохранение токена в бд
                if (IsSaveUser)
                {
                    DateTime expiration = response.Data.Expiration;
                    var settings = await _dbContext.Settings.FirstAsync();
                    settings.AccessToken = token;
                    settings.ExpirationToken = expiration;
                    _dbContext.Update(settings);
                    await _dbContext.SaveChangesAsync();
                }


            }
            else
            {
                //Ошибка авторизации. 

                if (response.Message.ErrorCode == Api.ErrorCodes.email_not_confirmed)
                {
                    //Электронная почта не подтверждена.
                    ErrorEmailNotConfirmMessage = "Электронная почта не подтверждена. ";
                }
                else
                {
                    ErrorMessage = response.Message.ErrorMessage;
                }
            }
        }
        [Reactive]
        public bool IsSaveUser { get; set; } = false;

        [Reactive]
        public string ErrorMessage { get; set; } = string.Empty;

        [Reactive]
        public string ErrorEmailNotConfirmMessage { get; set; } = string.Empty;

    }
}
