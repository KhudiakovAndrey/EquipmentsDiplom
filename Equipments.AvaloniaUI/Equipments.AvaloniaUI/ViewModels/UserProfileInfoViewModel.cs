using Equipments.AvaloniaUI.Resources;
using Equipments.AvaloniaUI.Services;
using HarfBuzzSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class UserProfileInfoViewModel : RoutableViewModelBase
    {

        private readonly MainMenuWindowViewModel _mainVM;
        public UserProfileInfoViewModel(MainMenuWindowViewModel mainVM)
            : base(nameof(UserProfileInfoViewModel))
        {
            _mainVM = mainVM;
            Initialize();
        }
        public UserProfileInfoViewModel()
            : base(nameof(UserProfileInfoViewModel))
        {

        }

        private void Initialize()
        {
            Role = TokenService.GetRoles(JwtTokenData.AccessToken ?? string.Empty)[0];
        }
        public string Role { get; set; }
    }
}
