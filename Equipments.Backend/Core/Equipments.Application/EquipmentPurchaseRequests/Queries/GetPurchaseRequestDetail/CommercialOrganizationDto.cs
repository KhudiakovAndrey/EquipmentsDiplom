using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;

namespace Equipments.Application.EquipmentPurchaseRequests.Queries
{
    public partial class GetPurchaseRequestDetail
    {
        public class CommercialOrganizationDto : IMapWith<CommercialOrganization>
        {
            public int ID { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Website { get; set; } = string.Empty;

            public void Mapping(Profile profile)
            {
                profile.CreateMap<CommercialOrganization, CommercialOrganizationDto>()
                    .ForMember(dto => dto.Name,
                        opt => opt.MapFrom(org => org.Name))
                    .ForMember(dto => dto.Email,
                        opt => opt.MapFrom(org => org.Email))
                    .ForMember(dto => dto.Phone,
                        opt => opt.MapFrom(org => org.Phone))
                    .ForMember(dto => dto.Website,
                        opt => opt.MapFrom(org => org.Website));
            }
        }
    }
}
