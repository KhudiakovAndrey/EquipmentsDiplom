using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Application.EquipmentsServiceRequest.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Equipments.WebAPI.Models
{
    public class CreateServiceRequestDto : IMapWith<CreateServiceRequest.Command>
    {
        [Required]
        public Guid IDResponsible { get; set; }
        [Required]
        public Guid IDSystemAdministrator { get; set; }
        [Required]
        public string EquipmentType { get; set; } = string.Empty;
        [Required]
        public string ProblemType { get; set; } = string.Empty;
        public string? DetailedDescription { get; set; } = string.Empty;
        [Required]
        public string BrokenEquipmentDescription { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateServiceRequestDto, CreateServiceRequest.Command>()
                .ForMember(createDto => createDto.IDResponsible,
                    opt => opt.MapFrom(create => create.IDResponsible))
                .ForMember(createDto => createDto.IDSystemAdministrator,
                    opt => opt.MapFrom(create => create.IDSystemAdministrator))
                .ForMember(createDto => createDto.EquipmentType,
                    opt => opt.MapFrom(create => create.EquipmentType))
                .ForMember(createDto => createDto.ProblemType,
                    opt => opt.MapFrom(create => create.ProblemType))
                .ForMember(createDto => createDto.DetailedDescription,
                    opt => opt.MapFrom(create => create.DetailedDescription))
                .ForMember(createDto => createDto.BrokenEquipmentDescription,
                    opt => opt.MapFrom(create => create.BrokenEquipmentDescription))
        }
    }
}
