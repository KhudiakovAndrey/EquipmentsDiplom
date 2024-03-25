using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Equipments.Queries
{
    public partial class GetPageEquipmentsList
    {
        public class PagedListEquipments
        {
            public PagedListEquipments(int pageNumber, int pageSize, List<PageItemEquipmentsDto> equipments)
            {
                PageNumber = pageNumber;
                PageSize = pageSize;
                TotalCount = equipments.Count;

                Equipments = equipments.Skip((pageNumber - 1) * PageSize).Take(pageSize).ToList();
            }

            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalCount { get; set; }
            public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
            public List<PageItemEquipmentsDto> Equipments { get; set; }
        }
    }
}
