using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;

namespace Equipments.Application.Departments.Queries
{
    public partial class GetDepartments
    {
        public class DepartmentDto : IMapWith<Department>
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public void Mapping(Profile profile)
            {
                profile.CreateMap<Department, DepartmentDto>()
                    .ForMember(dto => dto.ID,
                        opt => opt.MapFrom(entity => entity.Id))
                    .ForMember(dto => dto.Name,
                        opt => opt.MapFrom(entity => entity.Name));
            }
        }
    }
}
