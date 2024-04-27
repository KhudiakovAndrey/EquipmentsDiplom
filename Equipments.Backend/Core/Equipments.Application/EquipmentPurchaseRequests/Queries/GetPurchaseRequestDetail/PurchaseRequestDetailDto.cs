using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Application.Models;
using Equipments.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Equipments.Application.EquipmentPurchaseRequests.Queries
{
    public partial class GetPurchaseRequestDetail
    {
        public class PurchaseRequestDetailDto : IMapWith<EquipmentPurchaseRequest>
        {
            public EmployDto SystemAdministration { get; set; } = new();
            public string PurchaseReason { get; set; } = string.Empty;
            public DateTime CreationDate { get; set; }
            public string PurchaseDeadline { get; set; } = string.Empty;

            public List<Queries.GetPurchaseRequestDetail.CommercialOffersDto> CommercialOffers { get; set; } = new();
            public List<PurchasedEquipment> PurchasedEquipments { get; set; } = new();
            public void Mapping(Profile profile)
            {
                profile.CreateMap<EquipmentPurchaseRequest, PurchaseRequestDetailDto>()
                    .ForMember(dto => dto.SystemAdministration,
                        opt => opt.MapFrom(purchaseReq => purchaseReq.IdsystemAdministratorNavigation))
                    .ForMember(dto => dto.PurchaseReason,
                        opt => opt.MapFrom(purchaseReq => purchaseReq.PurchaseReason))
                    .ForMember(dto => dto.CreationDate,
                        opt => opt.MapFrom(purchaseReq => purchaseReq.CreationDate))
                    .ForMember(dto => dto.PurchaseDeadline,
                        opt => opt.MapFrom(purchaseReq => purchaseReq.PurchaseDeadline));
            }
        }
    }
}
