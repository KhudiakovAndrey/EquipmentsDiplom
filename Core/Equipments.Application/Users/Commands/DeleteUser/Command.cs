using MediatR;

namespace Equipments.Application.Users.Commands
{
    public partial class DeleteUser
    {
        public class Command : IRequest
        {
            public int IdUser { get; set; }
        }
    }

}
