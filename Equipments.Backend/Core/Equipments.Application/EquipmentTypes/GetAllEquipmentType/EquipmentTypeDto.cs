using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentTypes
{
    public partial class GetAllEquipmentType
    {
        public class EquipmentTypeDto : IMapWith<EquipmentType>
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;

            public void Mapping(Profile profile)
            {
                profile.CreateMap<EquipmentType, EquipmentTypeDto>()
                    .ForMember(typeDto => typeDto.Name,
                        opt => opt.MapFrom(type => type.Name));
            }
        }
    }
}
