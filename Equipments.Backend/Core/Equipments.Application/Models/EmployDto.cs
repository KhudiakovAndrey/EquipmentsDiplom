using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;

namespace Equipments.Application.Models
{
    public class EmployDto : IMapWith<Employee>
    {
        public Guid ID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Post { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public int RoleID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployDto>()
                .ForMember(emDto => emDto.FullName,
                    opt => opt.MapFrom(em => em.FullName))
                .ForMember(emDto => emDto.Post,
                    opt => opt.MapFrom(em => em.IdpostNavigation.Name))
                .ForMember(emDto => emDto.Department,
                    opt => opt.MapFrom(em => em.IddepartmentNavigation.Name))
                .ForMember(emDto => emDto.Photo,
                    opt => opt.MapFrom(em => em.Photo))
                .ForMember(emDto => emDto.RoleID,
                    opt => opt.MapFrom(em => em.IDEmployeeRole));
        }
    }
}
