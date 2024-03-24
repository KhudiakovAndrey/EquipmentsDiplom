using MediatR;
using System;

namespace Equipments.Application.Users.Commands
{
    public partial class CreateUser
    {
        public class Command : IRequest<Guid>
        {
            public string Userlogin { get; set; }
            public string Userpassword { get; set; }
            public string Email { get; set; }
        }
    }
}
