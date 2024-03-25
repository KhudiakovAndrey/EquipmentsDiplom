using Equipments.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Commands
{
    public partial class CreateUser
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(createUserCommand =>
                    createUserCommand.Userlogin)
                    .NotEmpty().WithMessage("Логин не может быть пустым")
                    .MaximumLength(50).WithMessage("Длина логина не должна превышать 50 символов");
                RuleFor(createUserCommand =>
                    createUserCommand.Userpassword)
                    .NotEmpty().WithMessage("Пароль не может быть пустым")
                    .MaximumLength(20).WithMessage("Длина пароля не должна превышать 20 символов")
                    .MinimumLength(8).WithMessage("Пароль должен иметь больше 7 символов")
                    .Matches(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]").WithMessage("Пароль должнен соответствовать требованиям: a-z, A-Z, спец. символы");
                RuleFor(createUserCommand =>
                    createUserCommand.Email)
                    .NotEmpty().WithMessage("Электронная почта не может быть пустой")
                    .MaximumLength(254).WithMessage("Длина электронной почты не должна превышать 254 символов")
                    .EmailAddress().WithMessage("Электронная почта не соответствует формату");


            }
        }
    }
}
