﻿using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetPageServiceReqeust
    {
        public class ServiceRequestVM : IMapWith<EquipmentServiceRequest>
        {
            public Guid ID { get; set; }
            public string Responsible { get; set; } = string.Empty;
            public string SystemAdministration { get; set; } = string.Empty;
            public string ProblemType { get; set; } = string.Empty;
            public DateTime CreationDate { get; set; }
            public void Mapping(Profile profile)
            {
                profile.CreateMap<EquipmentServiceRequest, ServiceRequestVM>()
                    .ForMember(reqDto => reqDto.Responsible,
                        opt => opt.MapFrom(req => req.IdresponsibleNavigation.FullName))
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