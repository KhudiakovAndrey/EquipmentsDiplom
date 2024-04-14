using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Application.RequestStatuses;
using Equipments.Domain.Entities;
using System;

namespace Equipments.Application.Models
{
    public class RequestDetailsVM : IMapWith<RequestStatusChange>
    {
        public int ID { get; set; }
        public DateTime ChangeStatusDate { get; set; }
        public RequestStatusDto Status { get; set; }
        public string Description { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RequestStatusChange, RequestDetailsVM>()
                .ForMember(statusDto => statusDto.ChangeStatusDate,
                    opt => opt.MapFrom(status => status.StatusChangeDate))
                .ForMember(statusDto => statusDto.Status,
                    opt => opt.MapFrom(status => status.StatusNavigation))
                .ForMember(statusDto => statusDto.Description,
                    opt => opt.MapFrom(status => status.WorkDescription));
        }
    }
}
