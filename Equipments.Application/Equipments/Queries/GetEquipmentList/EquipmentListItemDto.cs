using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Equipments.Queries.GetEquipmentList
{
    public partial class GetEquipmentList
    {
        public class EquipmentListItemDto : IMapWith<Equipment>
        {
            public int IdEquipment { get; set; }
            public string Title { get; set; }
            public bool Isgroup { get; set; }
            public int IdStatusEquipment { get; set; }
            public int IdTypeEquipment { get; set; }
            public void Mapping(Profile profile)
            {
                profile.CreateMap<Equipment, EquipmentListItemDto>()
                    .ForMember(eqDto => eqDto.IdEquipment,
                        opt => opt.MapFrom(eq => eq.IdEquipment))
                    .ForMember(eqDto => eqDto.Title,
                        opt => opt.MapFrom(eq => eq.Title))
                    .ForMember(eqDto => eqDto.Isgroup,
                        opt => opt.MapFrom(eq => eq.Isgroup))
                    .ForMember(eqDto => eqDto.IdStatusEquipment,
                        opt => opt.MapFrom(eq => eq.IdStatusEquipment))
                    .ForMember(eqDto => eqDto.IdTypeEquipment,
                        opt => opt.MapFrom(eq => eq.IdTypeEquipment));
            }
        }
    }
}
