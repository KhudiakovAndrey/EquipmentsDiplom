using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;

namespace Equipments.Application.Models
{
    public class RequestStatusDto : IMapWith<RequestStatusChange>
    {
        public int ID { get; set; }
        public DateTime ChangeStatusDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RequestStatusChange, RequestStatusDto>()
                .ForMember(statusDto => statusDto.ChangeStatusDate,
                    opt => opt.MapFrom(status => status.StatusChangeDate))
                .ForMember(statusDto => statusDto.Status,
                    opt => opt.MapFrom(status => status.StatusNavigation.Name))
                .ForMember(statusDto => statusDto.Description,
                    opt => opt.MapFrom(status => status.WorkDescription));
        }
    }
}
