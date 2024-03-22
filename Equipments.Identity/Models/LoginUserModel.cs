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
        [StringLength(256)]
        public string Username { get; set; }
        [Required]
        [StringLength(256)]
        public string Password { get; set; }
    }
}
