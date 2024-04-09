using FluentValidation;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetServiceRequestDetails
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.ID).NotEqual(Guid.Empty);
            }
        }
    }
}
