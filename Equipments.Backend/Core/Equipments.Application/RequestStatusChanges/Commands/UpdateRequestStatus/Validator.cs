using FluentValidation;
using System;

namespace Equipments.Application.RequestStatusChanges.Commands
{
    public partial class UpdateRequestStatus
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.ID).NotEmpty();
                RuleFor(x => x.IDStatus).NotEmpty();
                RuleFor(x => x.IDRequestService).NotNull().NotEqual(Guid.Empty);
            }
        }
    }
}
