using FluentValidation;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Commands
{
    public partial class UpdateServiceRequest
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.ID).NotEqual(Guid.Empty);
                RuleFor(x => x.IDResponsible).NotEqual(Guid.Empty);
                RuleFor(x => x.IDSystemAdministration).NotEqual(Guid.Empty);
                RuleFor(x => x.EquipmentType).NotEmpty().MaximumLength(255);
                RuleFor(x => x.ProblemType).NotEmpty().MaximumLength(255);
                RuleFor(x => x.Description).NotEmpty().MaximumLength(255);
            }
        }
    }
}
