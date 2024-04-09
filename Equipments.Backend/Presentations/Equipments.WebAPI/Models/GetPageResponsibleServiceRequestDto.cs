using Equipments.Application.Common.Mappings;
using Equipments.Application.Models;
using System;
using Equipments.Application.EquipmentsServiceRequest.Queries;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Equipments.WebAPI.Models
{
    public class GetPageResponsibleServiceRequestDto : IMapWith<GetPageResponsibleRequest.Query>
    {
        [Required]
        public PaginationQuery Pagination { get; set; } = new();
        public Guid IDResponsible { get; set; }
        public Guid? IDSystemAdministrator { get; set; }
        public DateTime? CreationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetPageResponsibleServiceRequestDto, GetPageResponsibleRequest.Query>()
                .ForMember(pageQuery => pageQuery.Pagination,
                    opt => opt.MapFrom(pageDto => pageDto.Pagination))
                .ForMember(pageQuery => pageQuery.IDResponsible,
                    opt => opt.MapFrom(pageDto => pageDto.IDResponsible))
                 .ForMember(pageQuery => pageQuery.CreationDate,
                    opt => opt.MapFrom(pageDto => pageDto.CreationDate))
                 .ForMember(pageQuery => pageQuery.IDSystemAdministrator,
                    opt => opt.MapFrom(pageDto => pageDto.IDSystemAdministrator));
        }

    }
}
