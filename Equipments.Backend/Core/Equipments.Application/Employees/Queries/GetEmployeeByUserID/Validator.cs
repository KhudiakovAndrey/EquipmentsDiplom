using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetEmployeeByID
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.IDEmployee).NotEqual(Guid.Empty);
            }
        }
    }
}
