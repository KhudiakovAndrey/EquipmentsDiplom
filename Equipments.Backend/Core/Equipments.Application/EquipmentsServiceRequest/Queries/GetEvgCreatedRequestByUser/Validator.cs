using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetEvgCreatedRequestByUser
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.IDUser)
                    .NotEqual(Guid.Empty)
                    .NotNull();
            }
        }
    }
}
