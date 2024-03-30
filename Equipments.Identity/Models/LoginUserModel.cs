using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Identity.Models
{
    public class LoginUserModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "Логин не должен превышать 256 символов")]
        public string Username { get; set; } = string.Empty;
        [Required]
        [StringLength(256, ErrorMessage = "Пароль не должен превышать 256 символов")]
        public string Password { get; set; } = string.Empty;
    }
}
