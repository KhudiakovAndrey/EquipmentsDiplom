using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetPageResponsibleRequest
    {
        public class RequestVm : IMapWith<EquipmentServiceRequest>
        {
            public Guid ID { get; set; }
            public EmployeDto SystemAdministration { get; set; } = new();
            public string ProblemType { get; set; } = string.Empty;
            public DateTime CreationDate { get; set; }
            public void Mapping(Profile profile)
            {
                profile.CreateMap<EquipmentServiceRequest, RequestVm>()
                    .ForMember(reqDto => reqDto.SystemAdministration,
                        opt => opt.MapFrom(req => req.IdsystemAdministratorNavigation.FullName))
                    .ForMember(reqDto => reqDto.ProblemType,
                        opt => opt.MapFrom(req => req.IdproblemTypeNavigation.IdequipmentTypeNavigation.Name
                        + " "
                        + req.IdproblemTypeNavigation.Description))
                    .ForMember(reqDto => reqDto.CreationDate,
                        opt => opt.MapFrom(req => req.CreationDate));
            }

        }
    }
}
