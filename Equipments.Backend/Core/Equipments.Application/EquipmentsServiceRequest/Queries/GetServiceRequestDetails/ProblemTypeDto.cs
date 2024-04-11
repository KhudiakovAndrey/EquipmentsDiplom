using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetServiceRequestDetails
    {
        public class ProblemTypeDto : IMapWith<ProblemType>
        {
            public int ID { get; set; }
            public string EquipmentType { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public void Mapping(Profile profile)
            {
                profile.CreateMap<ProblemType, ProblemTypeDto>()
                    .ForMember(problemDto => problemDto.EquipmentType,
                        opt => opt.MapFrom(problem => problem.IdequipmentTypeNavigation.Name))
                    .ForMember(problemDto => problemDto.Description,
                        opt => opt.MapFrom(problem => problem.Description));
            }
        }
    }
}
