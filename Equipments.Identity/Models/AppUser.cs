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
        public int WorkerId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
