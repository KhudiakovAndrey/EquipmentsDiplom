using FluentValidation;

namespace Equipments.Application.RequestStatusChanges.Commands
{
    public partial class DeleteRequestStatus
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.ID).NotEmpty();
            }
        }
    }
}
