using MediatR;
using System;

namespace Equipments.Application.Employees.Commands
{
    public partial class ChangeImage
    {
        public class Command : IRequest
        {
            public Guid ID { get; set; }
            public string Image { get; set; }
        }
    }
}
