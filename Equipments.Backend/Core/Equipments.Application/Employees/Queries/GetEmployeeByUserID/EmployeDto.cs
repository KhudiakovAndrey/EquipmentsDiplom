using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;

namespace Equipments.Application.Employees.Queries
{
    public partial class GetEmployeeByID
    {
        public class EmployeDto : IMapWith<Employee>
        {
            public Guid ID { get; set; }
            public string FullName { get; set; }
            public string Post { get; set; }
            public string Department { get; set; }
            public string NumberAssignedOffice { get; set; }
            public string DescriptionAssignedOffice { get; set; }
            public void Mapping(Profile profile)
            {
                profile.CreateMap<Employee, EmployeDto>()
                    .ForMember(dto => dto.ID,
                        opt => opt.MapFrom(entity => entity.Id))
                    .ForMember(dto => dto.FullName,
                        opt => opt.MapFrom(entity => entity.FullName))
                    .ForMember(dto => dto.Post,
                        opt => opt.MapFrom(entity => entity.IdpostNavigation.Name))
                    .ForMember(dto => dto.Department,
                        opt => opt.MapFrom(entity => entity.IddepartmentNavigation.Name))
                    .ForMember(dto => dto.NumberAssignedOffice,
                        opt => opt.MapFrom(entity => entity.IdassignedOfficeNavigation.Number))
                    .ForMember(dto => dto.DescriptionAssignedOffice,
                        opt => opt.MapFrom(entity => entity.IdassignedOfficeNavigation.Description));
            }
        }
    }
}
