namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetAllByPrevMonth
    {
        public class EquipmentTypeDto
        {
            public string EquipmentType { get; set; }
            public int RequestCount { get; set; }
        }
    }
}
