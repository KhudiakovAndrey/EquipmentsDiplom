using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Application.EquipmentsServiceRequest.Commands;
using System;

namespace Equipments.WebAPI.Models
{
    public class UpdateServiceRequestDto : IMapWith<UpdateServiceRequest.Command>
    {
        public Guid ID { get; set; }
        public Guid IDResponsible { get; set; }
        public Guid IDSystemAdministration { get; set; }
        public string EquipmentType { get; set; } = string.Empty;
        public string ProblemType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BrokenEquipmentDescription { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateServiceRequestDto, UpdateServiceRequest.Command>()
                .ForMember(updateCommand => updateCommand.IDResponsible,
                    opt => opt.MapFrom(dto => dto.IDResponsible))
                .ForMember(updateCommand => updateCommand.IDSystemAdministration,
                    opt => opt.MapFrom(dto => dto.IDSystemAdministration))
                .ForMember(updateCommand => updateCommand.EquipmentType,
                    opt => opt.MapFrom(dto => dto.EquipmentType))
                .ForMember(updateCommand => updateCommand.ProblemType,
                    opt => opt.MapFrom(dto => dto.ProblemType))
                .ForMember(updateCommand => updateCommand.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                .ForMember(updateCommand => updateCommand.BrokenEquipmentDescription,
                    opt => opt.MapFrom(dto => dto.BrokenEquipmentDescription));
        }
    }
}
