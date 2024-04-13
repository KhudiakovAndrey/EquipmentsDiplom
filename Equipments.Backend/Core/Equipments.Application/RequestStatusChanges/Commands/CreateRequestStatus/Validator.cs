using FluentValidation;
using System;

namespace Equipments.Application.RequestStatusChanges.Commands
{
    public partial class CreateRequestStatus
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.IDRequestService).NotNull().NotEqual(Guid.Empty);
                RuleFor(x => x.IDStatus).NotNull().NotEmpty();
            }
        }
    }
}
