﻿using System;
using System.Collections.Generic;

namespace Equipments.Application.Models
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(List<T> items, int pageNumber, int pageSize, int totalCount, int countFound)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            CountFound = countFound;
        }

        public List<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int CountFound { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)CountFound / PageSize);
    }
}
