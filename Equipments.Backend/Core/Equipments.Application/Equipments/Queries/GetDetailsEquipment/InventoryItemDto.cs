using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;

namespace Equipments.Application.Equipments.Queries.GetDetailsEquipment
{
    public partial class GetDetailsEquipment
    {
        public class InventoryItemDto : IMapWith<InventoryObject>
        {
            public int IdAdditionallyEquipment { get; set; }
            public string InventoryNumber { get; set; }
            public int IdEquipmentCustodians { get; set; }
            public decimal CostEq { get; set; }
            public DateTime? DateAdd { get; set; }
            public DateTime? DateUse { get; set; }
            public DateTime? DateDelete { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<InventoryObject, InventoryItemDto>()
                    .ForMember(invDto => invDto.IdAdditionallyEquipment,
                        opt => opt.MapFrom(inv => inv.IdAdditionallyEquipment))
                    .ForMember(invDto => invDto.InventoryNumber,
                        opt => opt.MapFrom(inv => inv.InventoryNumber))
                    .ForMember(invDto => invDto.IdEquipmentCustodians,
                        opt => opt.MapFrom(inv => inv.IdEquipmentCustodians))
                    .ForMember(invDto => invDto.CostEq,
                        opt => opt.MapFrom(inv => inv.CostEq))
                    .ForMember(invDto => invDto.DateAdd,
                        opt => opt.MapFrom(inv => inv.DateAdd))
                    .ForMember(invDto => invDto.DateUse,
                        opt => opt.MapFrom(inv => inv.DateUse))
                    .ForMember(invDto => invDto.DateDelete,
                        opt => opt.MapFrom(inv => inv.DateDelete));
            }
        }

    }

}
