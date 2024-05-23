using FluentValidation;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetCountCreatedRequestByDate
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.IDUser)
                    .NotEqual(Guid.Empty)
                    .NotNull();
                RuleFor(x => x.StartDate)
                    .NotNull();
                RuleFor(x => x.EndDate)
                    .NotNull();
            }
        }
    }
}
