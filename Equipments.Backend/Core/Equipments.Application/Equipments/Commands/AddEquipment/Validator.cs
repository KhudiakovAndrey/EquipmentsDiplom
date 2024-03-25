using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Equipments.Commands
{
    public partial class AddEquipment
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(addEquipmentCommand =>
                    addEquipmentCommand.Title)
                    .NotEmpty().WithMessage("Краткое именование - обязательное поле")
                    .Length(50).WithMessage("Краткое наименование не должно превышать 50 символов");
                RuleFor(addEquipmentCommand =>
                    addEquipmentCommand.FullTitle)
                    .Length(500).WithMessage("Полное наименование не должно первышать 500 символов");
                RuleFor(addEquipmentCommand =>
                    addEquipmentCommand.IdStatus)
                    .NotEmpty().WithMessage("Статус не может быть пустым")
                    .NotEqual(0).WithMessage("Статус невалиден")
                    .NotNull().WithMessage("Статус не может быть пустым");
                RuleFor(addEquipmentCommand =>
                    addEquipmentCommand.IdType)
                    .NotEmpty().WithMessage("Тип не может быть пустым")
                    .NotEqual(0).WithMessage("Тип невалиден")
                    .NotNull().WithMessage("Тип не может быть пустым");

            }
        }
    }
}
