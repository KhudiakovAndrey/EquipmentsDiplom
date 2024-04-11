using FluentValidation;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Commands
{
    public partial class DeleteServiceRequest
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.ID)
                    .NotEqual(Guid.Empty);
            }
        }
    }
}
