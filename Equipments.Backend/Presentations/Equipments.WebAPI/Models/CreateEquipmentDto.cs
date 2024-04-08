using AutoMapper;
using Equipments.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Models
{
    //public class CreateEquipmentDto : IMapWith<AddEquipment.Command>
    //{
    //    public string Title { get; set; } = string.Empty;
    //    public string FullTitle { get; set; } = string.Empty;
    //    public bool IsGroup { get; set; }
    //    public int IdStatus { get; set; }
    //    public int IdType { get; set; }

    //    public void Mapping(Profile profile)
    //    {
    //        profile.CreateMap<CreateEquipmentDto, AddEquipment.Command>()
    //            .ForMember(createCommand => createCommand.Title,
    //                opt => opt.MapFrom(createDto => createDto.Title))
    //            .ForMember(createCommand => createCommand.FullTitle,
    //                opt => opt.MapFrom(createDto => createDto.FullTitle))
    //            .ForMember(createCommand => createCommand.IsGroup,
    //                opt => opt.MapFrom(createDto => createDto.IsGroup))
    //            .ForMember(createCommand => createCommand.IdStatus,
    //                opt => opt.MapFrom(createDto => createDto.IdStatus))
    //            .ForMember(createCommand => createCommand.IdType,
    //                opt => opt.MapFrom(createDto => createDto.IdType));
    //    }
    //}
}