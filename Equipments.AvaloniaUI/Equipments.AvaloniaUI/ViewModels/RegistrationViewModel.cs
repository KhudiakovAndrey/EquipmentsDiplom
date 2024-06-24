using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly UserService _userService;
        public event EventHandler<string> FailedRegistraion;
        public event EventHandler<RegViewModel> SuccessfulRegistration;
        private readonly MainMenuWindowViewModel _ownerVm;
        public RegistrationViewModel(UserService registrationService, MainMenuWindowViewModel ownerVm)
        {
            _userService = registrationService;
            _ownerVm = ownerVm;

            Register = new RegViewModel();

            IObservable<bool> isExecuteRegistrationCommand = this.WhenAnyValue(
                vm => vm.Register.Username,
                vm => vm.Register.Email,
                vm => vm.Register.Password,
                vm => vm.Register.ConfirmPassword, (u, e, p, c) => RegViewModel.isValiable(Register));

            RegistrationCommand = ReactiveCommand.CreateFromTask(Registration, isExecuteRegistrationCommand);
        }

        public ReactiveCommand<Unit, Unit> RegistrationCommand { get; private set; }
        private async Task Registration()
        {
            var response = await _userService.RegistrationUserAsync(Register);
            if (response.IsSucces)
            {
                SuccessfulRegistration?.Invoke(this, Register);
            }
            else
            {
                //await _ownerVm.ShowDialogHostAsync(response.Message.ErrorMessage);
            }
        }

        [Reactive] public RegViewModel Register { get; set; }
    }
}
