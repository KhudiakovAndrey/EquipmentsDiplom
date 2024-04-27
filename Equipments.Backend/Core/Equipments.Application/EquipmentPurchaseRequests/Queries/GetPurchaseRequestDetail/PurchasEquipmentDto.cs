using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;

namespace Equipments.Application.EquipmentPurchaseRequests.Queries
{
    public partial class GetPurchaseRequestDetail
    {
        public class PurchasEquipmentDto : IMapWith<PurchasedEquipment>
        {
            public int ID { get; set; }
            public string EquipmentName { get; set; } = string.Empty;
            public string MeasurementUnit { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public string AdditionalCondition { get; set; } = string.Empty;
            public void Mapping(Profile profile)
            {
                profile.CreateMap<PurchasedEquipment, PurchasEquipmentDto>()
                    .ForMember(dto => dto.EquipmentName,
                        opt => opt.MapFrom(purch => purch.EquipmentName))
                    .ForMember(dto => dto.MeasurementUnit,
                        opt => opt.MapFrom(purch => purch.MeasurementUnit))
                    .ForMember(dto => dto.Quantity,
                        opt => opt.MapFrom(purch => purch.Quantity))
                    .ForMember(dto => dto.AdditionalCondition,
                        opt => opt.MapFrom(purch => purch.AdditionalCondition));
            }
        }
    }
}
