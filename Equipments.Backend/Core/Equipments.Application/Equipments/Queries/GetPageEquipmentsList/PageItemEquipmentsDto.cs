using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;

namespace Equipments.Application.Equipments.Queries
{
    public partial class GetPageEquipmentsList
    {

        public class PageItemEquipmentsDto : IMapWith<Equipment>
        {
            public int IdEquipment { get; set; }
            public string Title { get; set; } = string.Empty;
            public bool Isgroup { get; set; }
            public string Status { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
            public void Mapping(Profile profile)
            {
                profile.CreateMap<Equipment, PageItemEquipmentsDto>()
                    .ForMember(eqDto => eqDto.IdEquipment,
                        opt => opt.MapFrom(eq => eq.IdEquipment))
                    .ForMember(eqDto => eqDto.Title,
                        opt => opt.MapFrom(eq => eq.Title))
                    .ForMember(eqDto => eqDto.Isgroup,
                        opt => opt.MapFrom(eq => eq.Isgroup))
                    .ForMember(eqDto => eqDto.Status,
                        opt => opt.MapFrom(eq => eq.IdStatusEquipmentNavigation.Title))
                    .ForMember(eqDto => eqDto.Type,
                        opt => opt.MapFrom(eq => eq.IdTypeEquipmentNavigation.Title));
            }
        }
    }
}
