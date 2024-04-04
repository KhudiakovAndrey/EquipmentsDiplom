using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Models
{
    public class RegViewModel : ReactiveObject
    {
        [DataMember]
        [Required(ErrorMessage = "Обязятельное поле для заполнения")]
        [StringLength(50, ErrorMessage = "Длина логина не должна превышать 50 символов")]
        [Reactive] public string Username { get; set; } = string.Empty;

        [DataMember]
        [Required(ErrorMessage = "Обязятельное поле для заполнения")]
        [StringLength(254, ErrorMessage = "Длина электронной почты не должна превышать 254 символов")]
        [EmailAddress]
        [Reactive] public string Email { get; set; } = string.Empty;


        [DataMember]
        [Required(ErrorMessage = "Обязятельное поле для заполнения")]
        [StringLength(20, ErrorMessage = "Пароль не должен быть длиннее 20 символов")]
        [MinLength(8, ErrorMessage = "Пароль должен начинаться от 8 символов")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}$"
,
            ErrorMessage = "Пароль должнен соответствовать требованиям: a-z, A-Z, спец. символы")]
        [Reactive] public string Password { get; set; } = string.Empty;

        [DataMember]
        [Required(ErrorMessage = "Обязятельное поле для заполнения")]
        [Compare("Password", ErrorMessage = "Пароль не совпадает")]
        [Reactive] public string ConfirmPassword { get; set; } = string.Empty;

        public static bool isValiable(RegViewModel model)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, results, true);

            return isValid;
        }
    }
}
