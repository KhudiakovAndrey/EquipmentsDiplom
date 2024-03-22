using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Commands
{
    public partial class UpdateUser
    {
        public class Command : IRequest
        {
            public int Iduser { get; set; }
            public string Userlogin { get; set; }
            public string Userpassword { get; set; }
            public string Email { get; set; }
            public bool Isactive { get; set; }
            public int? Idworker { get; set; }
        }
    }
}
