using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using Equipments.AvaloniaUI.Services.API;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class AuthorizationViewModel : ViewModelBase
    {
        private readonly SettingsDbContext _dbContext;
        private readonly UserService _loginService;

        [Reactive]
        public LoginViewModel Login { get; set; } = new LoginViewModel();

        public AuthorizationViewModel(SettingsDbContext dbContext, UserService loginService)
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

            try
            {
                var response = await _loginService.LoginAsync(Login);
                if (response.IsSucces)
                {
                    string token = response.Data.Token;
                    DateTime expiration = response.Data.Expiration;

                    //Сохранение токена в бд
                    if (IsSaveUser)
                    {
                        try
                        {
                            var settings = await _dbContext.Settings.FirstAsync();
                            settings.AccessToken = token;
                            settings.ExpirationToken = expiration;
                            _dbContext.Update(settings);
                            await _dbContext.SaveChangesAsync();
                        }
                        catch (FileNotFoundException ex)
                        {
                            Log.Information(ex, "Не удалось найти файл настроек.");
                        }
                    }

                    AppConfiguration.AccesToken = token;
                    AppConfiguration.ExpirationToken = expiration;

                    OnAuthorizationSuccess?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    //Ошибка авторизации. 


                    if (response.Message.ErrorCode == Api.ErrorCodes.email_not_confirmed)
                    {
                        //Электронная почта не подтверждена.
                        ErrorEmailNotConfirmMessage = "Электронная почта не подтверждена. ";
                        EmailConfirm = response.Message.ErrorMessage;
                    }
                    else
                    {
                        ErrorMessage = response.Message.ErrorMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Исключение при обращении к серверу для авторизации");
            }
        }

        public async void ShowDialog()
        {
            await App.MainAuthVM?.ShowDialogHostAsync("Hello World!")!;
        }
        public event EventHandler? OnAuthorizationSuccess;

        [Reactive]
        public bool IsSaveUser { get; set; } = false;

        [Reactive]
        public string ErrorMessage { get; set; } = string.Empty;

        [Reactive]
        public string ErrorEmailNotConfirmMessage { get; set; } = string.Empty;
        [Reactive]
        public string EmailConfirm { get; private set; } = string.Empty;

    }
}
