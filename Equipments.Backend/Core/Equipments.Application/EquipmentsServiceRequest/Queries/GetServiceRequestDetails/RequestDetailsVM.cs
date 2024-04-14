using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Application.Models;
using Equipments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetServiceRequestDetails
    {
        public class RequestDetailsVM : IMapWith<EquipmentServiceRequest>
        {
            public Guid ID { get; set; }
            public EmployeDto Responsible { get; set; } = new();
            public EmployeDto SystemAdministrator { get; set; } = new();
            public ProblemTypeDto ProblemType { get; set; } = new();
            public string DetailedDescription { get; set; } = string.Empty;
            public string BrokenEquipmentDescription { get; set; } = string.Empty;
            public DateTime CreationDate { get; set; }
            public List<Models.RequestDetailsVM> Statues { get; set; } = new();
            public void Mapping(Profile profile)
            {
                profile.CreateMap<EquipmentServiceRequest, RequestDetailsVM>()
                    .ForMember(reqVm => reqVm.Responsible,
                        opt => opt.MapFrom(req => req.IdresponsibleNavigation))
                    .ForMember(reqVm => reqVm.SystemAdministrator,
                        opt => opt.MapFrom(req => req.IdsystemAdministratorNavigation))
                    .ForMember(reqVm => reqVm.ProblemType,
                        opt => opt.MapFrom(req => req.IdproblemTypeNavigation))
                    .ForMember(reqVm => reqVm.DetailedDescription,
                        opt => opt.MapFrom(req => req.DetailedDescription))
                    .ForMember(reqVm => reqVm.BrokenEquipmentDescription,
                        opt => opt.MapFrom(req => req.BrokenEquipmentDescription))
                    .ForMember(reqVm => reqVm.CreationDate,
                        opt => opt.MapFrom(req => req.CreationDate))
                    .ForMember(reqVm => reqVm.Statues,
                        opt => opt.MapFrom(req => req.RequestStatusChanges));
            }
        }
    }
}
