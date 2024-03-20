using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class Token
    {
        public string Key { get; set; }
        public string AccessToken { get; set; }
        public DateTime Expires { get; set; }
        public string Type { get; set; }
        public DateTime CreationTime { get; set; }
        public int UserId { get; set; }
        public string ClientId { get; set; }
        public string Data { get; set; }

        public virtual AppUser User { get; set; }
    }
}
