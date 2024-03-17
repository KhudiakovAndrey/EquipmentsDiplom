using MediatR;

namespace Equipments.Application.Users.Commands.CreateUser
{
    public partial class CreateUser
    {
        public class Command : IRequest<int>
        {
            public int Iduser { get; set; }
            public string Userlogin { get; set; }
            public string Userpassword { get; set; }
            public string Email { get; set; }
        }
    }
}
