using FluentValidation;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Commands
{
    public partial class CreateServiceRequest
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.IDResponsible)
                    .NotNull()
                    .NotEqual(Guid.Empty);
                RuleFor(x => x.IDSystemAdministrator)
                    .NotNull()
                    .NotEqual(Guid.Empty);
                RuleFor(x => x.EquipmentType)
                    .NotEmpty();
                RuleFor(x => x.ProblemType)
                    .NotEmpty();
                RuleFor(x => x.DetailedDescription)
                    .NotEmpty()
                    .MaximumLength(255);
                RuleFor(x => x.BrokenEquipmentDescription)
                    .NotEmpty()
                    .MaximumLength(255);
            }
        }
    }
}
