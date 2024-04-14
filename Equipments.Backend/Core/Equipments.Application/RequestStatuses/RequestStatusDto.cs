using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;

namespace Equipments.Application.RequestStatuses
{
    public class RequestStatusDto : IMapWith<RequestStatus>
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RequestStatus, RequestStatusDto>()
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(status => status.Name));
        }
    }
}
