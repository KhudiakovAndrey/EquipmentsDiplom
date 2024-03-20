using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class AppUser
    {
        public AppUser()
        {
            Tokens = new HashSet<Token>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int? WorkerId { get; set; }

        public virtual Worker Worker { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
