using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Employees.Commands
{
    public partial class ChangeImage
    {
        public class Validate : AbstractValidator<Command>
        {
            public Validate()
            {
                RuleFor(x => x.ID)
                    .NotEqual(Guid.Empty);
            }
        }
    }

}
