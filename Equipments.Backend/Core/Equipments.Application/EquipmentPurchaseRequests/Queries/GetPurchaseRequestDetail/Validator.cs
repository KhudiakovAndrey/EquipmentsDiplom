using FluentValidation;
using System;

namespace Equipments.Application.EquipmentPurchaseRequests.Queries
{
    public partial class GetPurchaseRequestDetail
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
