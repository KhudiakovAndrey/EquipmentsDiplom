using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class User
    {
        public int Iduser { get; set; }
        public string Userlogin { get; set; }
        public string Userpassword { get; set; }
        public string Email { get; set; }
        public DateTime? Datelastlogin { get; set; }
        public DateTime? Dateregistration { get; set; }
        public bool Isregemailactive { get; set; }
        public bool Isactive { get; set; }
        public Guid Rowguid { get; set; }
        public int? Idworker { get; set; }

        public virtual Worker IdworkerNavigation { get; set; }
    }
}
