using MediatR;

namespace Equipments.Application.Users.Commands.DeleteUser
{
    public partial class DeleteUser
    {
        public class Command : IRequest
        {
            public int IdUser { get; set; }
        }
    }

}
