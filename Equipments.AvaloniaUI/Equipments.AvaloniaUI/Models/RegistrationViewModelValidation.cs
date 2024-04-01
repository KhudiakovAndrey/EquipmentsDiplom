using Equipments.AvaloniaUI.ViewModels;
using ReactiveValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Models
{
    public class RegistrationViewModelValidation : ValidationRuleBuilder<RegistrationViewModel>
    {
        public RegistrationViewModelValidation()
        {
            RuleFor(vm => vm.Username)
                .NotEmpty().WithMessage("Поле обязательно для заполнения")
                .Length(256);
            RuleFor(vm => vm.Email)
                .NotEmpty()
                .Length(256)
                .Must(IsValidEmail).Throttle(1000);
            RuleFor(vm => vm.Password)
                .NotEmpty()
                .Matches(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]").WithMessage("Пароль должнен соответствовать требованиям: a-z, A-Z, спец. символы")
                .Length(50);
            RuleFor(vm => vm.ConfirmPassword)
                .NotEmpty()
                .Equal(Password)
                .Length(50);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
