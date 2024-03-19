using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Queries
{
    public partial class GetUserById
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(getUserQuery =>
                    getUserQuery.RowGuid)
                    .NotEqual(Guid.Empty).WithMessage("Идентификатор пользователя не может быть пустым");
            }
        }
    }
}
