using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Application.RequestStatusChanges.Commands;
using System;

namespace Equipments.WebAPI.Models
{
    public class CreateRequestStatusChangeDto : IMapWith<CreateRequestStatus.Command>
    {
        public Guid IDRequestService { get; set; }
        public int IDStatus { get; set; }
        public string Description { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRequestStatusChangeDto, CreateRequestStatus.Command>()
                .ForMember(createCommand => createCommand.IDRequestService,
                    opt => opt.MapFrom(dto => dto.IDRequestService))
                .ForMember(createCommand => createCommand.IDStatus,
                    opt => opt.MapFrom(dto => dto.IDStatus))
                .ForMember(createCommand => createCommand.Description,
                    opt => opt.MapFrom(dto => dto.Description));
        }
    }
}
