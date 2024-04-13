using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Application.RequestStatusChanges.Commands;
using System;

namespace Equipments.WebAPI.Models
{
    public class UpdateRequestStatusChangeDto : IMapWith<UpdateRequestStatus.Command>
    {
        public int ID { get; set; }
        public Guid IDRequestService { get; set; }
        public int IDStatus { get; set; }
        public string? Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateRequestStatusChangeDto, UpdateRequestStatus.Command>()
                .ForMember(updateCommand => updateCommand.ID,
                    opt => opt.MapFrom(dto => dto.ID))
                .ForMember(updateCommand => updateCommand.IDRequestService,
                    opt => opt.MapFrom(dto => dto.IDRequestService))
                .ForMember(updateCommand => updateCommand.IDStatus,
                    opt => opt.MapFrom(dto => dto.IDStatus))
                .ForMember(updateCommand => updateCommand.Description,
                    opt => opt.MapFrom(dto => dto.Description));
        }
    }
}
