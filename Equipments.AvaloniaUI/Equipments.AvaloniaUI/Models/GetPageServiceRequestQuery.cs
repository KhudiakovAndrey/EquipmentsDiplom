﻿using System;

namespace Equipments.AvaloniaUI.Models
{
    public class GetPageServiceRequestQuery
    {
        public PaginationVM Pagination { get; set; } = new();
        public Guid? IDResponsible { get; set; }
        public Guid? IDSystemAdministration { get; set; }
        public DateTime? CreationDate { get; set; }

    }
}