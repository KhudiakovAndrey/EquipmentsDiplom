using FluentValidation;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetPageResponsibleRequest
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.IDResponsible).NotEqual(Guid.Empty);
            }
        }
    }
}
