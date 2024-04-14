using System.Collections.Generic;

namespace Equipments.AvaloniaUI.Models
{
    public class PurchaseRequestList
    {
        public int TotalCount { get; set; }
        public List<PurchaseRequestModel> Items { get; set; }
    }
}
