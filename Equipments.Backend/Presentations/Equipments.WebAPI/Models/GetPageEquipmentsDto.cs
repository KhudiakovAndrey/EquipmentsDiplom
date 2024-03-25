using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Application.Equipments.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Models
{
    public class GetPageEquipmentsDto : IMapWith<GetPageEquipmentsList>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string FilterTitle { get; set; } = string.Empty;
        public bool? FilterIsGroup { get; set; }
        public string FilterStatus { get; set; } = string.Empty;
        public string FilterType { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetPageEquipmentsDto, GetPageEquipmentsList.Query>()
                .ForMember(pageQuery => pageQuery.PageNumber,
                    opt => opt.MapFrom(oageDto => oageDto.PageNumber))
                .ForMember(pageQuery => pageQuery.PageSize,
                    opt => opt.MapFrom(oageDto => oageDto.PageSize))
                .ForMember(pageQuery => pageQuery.FilterTitle,
                    opt => opt.MapFrom(oageDto => oageDto.FilterTitle))
                .ForMember(pageQuery => pageQuery.FilterIsGroup,
                    opt => opt.MapFrom(oageDto => oageDto.FilterIsGroup))
                .ForMember(pageQuery => pageQuery.FilterStatus,
                    opt => opt.MapFrom(oageDto => oageDto.FilterStatus))
                .ForMember(pageQuery => pageQuery.FilterType,
                    opt => opt.MapFrom(oageDto => oageDto.FilterType));

        }

    }
}
