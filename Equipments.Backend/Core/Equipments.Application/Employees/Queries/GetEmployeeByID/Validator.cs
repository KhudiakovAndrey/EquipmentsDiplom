using FluentValidation;
using System;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetEmployeeByID
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.IDUser)
                    .NotEqual(Guid.Empty);
            }
        }
    }
}
