using Equipments.Api;
using Equipments.AvaloniaUI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class LoginService : ApiService<LoginViewModel>
    {
        private readonly AppConfiguration _appConfiguration;

        public LoginService(AppConfiguration appConfiguration) : base(appConfiguration.IdentityUrl)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginViewModel model)
        {
            var responce = await PostAsync<LoginResponse>(_appConfiguration.AuthEndpoint + "/login", model);
            if (responce.IsSucces)
            {
                AccessToken = responce.Data.Token;
            }
            return responce;
        }

    }
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
