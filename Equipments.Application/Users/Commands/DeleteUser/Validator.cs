using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Commands
{
    public partial class DeleteUser
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(deleteUserCommand =>
                    deleteUserCommand.IdUser)
                    .NotEqual(0).WithMessage("ID пользователя не может быть равен 0");
            }
        }
    }
}
