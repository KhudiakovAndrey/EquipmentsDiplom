using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using Equipments.AvaloniaUI.Services;
using Equipments.AvaloniaUI.Services.API;
using HarfBuzzSharp;
using IdentityModel.Client;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class UserProfileInfoViewModel : RoutableViewModelBase
    {
        private readonly MainMenuWindowViewModel _mainVM;
        private readonly EmployeesService _employeesService;
        private readonly UserService _userService;
        public UserProfileInfoViewModel(MainMenuWindowViewModel mainVM, EmployeesService employeesService, UserService userService)
            : base(nameof(UserProfileInfoViewModel))
        {
            _mainVM = mainVM;
            _employeesService = employeesService;
            _userService = userService;
            User = new UserModel
            {
                UserName = mainVM.User.UserName,
                Email = mainVM.User.Email,
                PhoneNumber = mainVM.User.PhoneNumber,
                Role = mainVM.User.Role,
                Employe = new FullEmployeModel
                {
                    FullName = mainVM.User.Employe.FullName,
                    Post = mainVM.User.Employe.Post,
                    Department = mainVM.User.Employe.Department,
                    NumberAssignedOffice = mainVM.User.Employe.NumberAssignedOffice,
                    DescriptionAssignedOffice = mainVM.User.Employe.DescriptionAssignedOffice,
                },
            };
            Role = JwtTokenData.AccessToken == null ? "Гость" : TokenService.GetRoles(JwtTokenData.AccessToken)[0];

            var isExecuteSave = this.WhenAnyValue(
                            vm => vm.ImageBytes,
                            vm => vm.User.Employe.FullName,
                            vm => vm.User.Employe.Post,
                            vm => vm.User.Employe.Department,
                            vm => vm.User.Employe.NumberAssignedOffice,
                            vm => vm.User.Employe.DescriptionAssignedOffice,
                            vm => vm.User.Email,
                            vm => vm.User.PhoneNumber,
                            (bytes,
                            fullname, post, dep, office, descoffice, email, phone) =>
                            bytes != null ||
                            (fullname != _mainVM.User.Employe.FullName ||
                            post != _mainVM.User.Employe.Post ||
                            dep != _mainVM.User.Employe.Department ||
                            office != _mainVM.User.Employe.NumberAssignedOffice ||
                            descoffice != _mainVM.User.Employe.DescriptionAssignedOffice ||
                            email != _mainVM.User.Email ||
                            phone != _mainVM.User.PhoneNumber)
                            );
            ;
            Save = ReactiveCommand.CreateFromTask(SaveCommand, isExecuteSave);
            SetDefaultImage = ReactiveCommand.CreateFromTask(SetDefaultImageCommand);
        }
        public UserProfileInfoViewModel()
            : base(nameof(UserProfileInfoViewModel))
        {
        }

        public ReactiveCommand<Unit, Unit> Save { get; set; }
        private async Task SaveCommand()
        {
            if (ImageBytes != null)
            {
                var response = await _employeesService.PutImageAsync(_mainVM.User.Employe.ID, ImageBytes);
                if (!response.IsSucces)
                    return;
            }
        }

        public ReactiveCommand<Unit, Unit> SetDefaultImage { get; private set; }
        private async Task SetDefaultImageCommand()
        {
            var response = await _employeesService.SetDefaultImageAsync(_mainVM.User.Employe.ID);
            if (response.IsSucces)
            {
                await _mainVM.ShowDialogHostAsync("Фото профиля изменится после перезапуска программы");
            }

        }
        [Reactive] public byte[]? ImageBytes { get; set; }
        public UserModel User { get; set; }

        public string Role { get; set; }
    }
}
