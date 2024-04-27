using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentPurchaseRequests.Queries
{
    public partial class GetPurchaseRequestDetail
    {
        public class CommercialOffersDto : IMapWith<CommercialOffer>
        {
            public int Id { get; set; }
            public decimal Price { get; set; }
            public CommercialOrganizationDto CommercialOrganization { get; set; } = new();
            public string InformationSource { get; set; } = string.Empty;
            public void Mapping(Profile profile)
            {
                profile.CreateMap<CommercialOffer, CommercialOffersDto>()
                    .ForMember(dto => dto.Price,
                        opt => opt.MapFrom(offer => offer.Price))
                    .ForMember(dto => dto.CommercialOrganization,
                        opt => opt.MapFrom(offer => offer.IdcommercialOrganizationNavigation))
                    .ForMember(dto => dto.InformationSource,
                        opt => opt.MapFrom(offer => offer.InformationSource));
            }
        }
    }
}
