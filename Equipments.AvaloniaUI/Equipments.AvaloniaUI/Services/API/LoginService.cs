using Equipments.Api;
using Equipments.AvaloniaUI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class LoginService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public LoginService(AppConfiguration appConfiguration) : base(appConfiguration.IdentityUrl)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task<ApiResponse<TokenResponse>> LoginAsync(LoginViewModel model)
        {
            var responce = await PostAsync<TokenResponse>(_appConfiguration.AuthEndpoint + "/login", model);
            if (responce.IsSucces)
            {
                AccessToken = responce.Data.Token;
            }
            return responce;
        }
        public async Task<ApiResponse<object>> SendEmailCode(string email)
        {
            var response = await PostAsync<object>(_appConfiguration.AuthEndpoint + "/resend-email-code", new { Email = email });
            return response;
        }
        public async Task<ApiResponse<object>> ConfirmEmail(string code)
        {
            var response = await PostAsync<object>(_appConfiguration.AuthEndpoint + "/confirm-email", new { Code = code });
            return response;
        }
    }
    public class TokenResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
