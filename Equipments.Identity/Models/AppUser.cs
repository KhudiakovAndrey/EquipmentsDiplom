using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Identity.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
        public DateTime LoginLastDate { get; set; }
        public string EmailConfirmationCode { get; set; } = string.Empty;
        public static string GenerateEmailConfirmationCode()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 6);
        }

    }
}
