﻿using MediatR;
using System;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetEmployeeByIDUser
    {
        public class Query : IRequest<EmployeDto>
        {
            public Guid IDUser { get; set; }
        }
    }
}
